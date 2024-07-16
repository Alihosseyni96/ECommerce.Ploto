using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System.Reflection;

namespace ECommerce.Ploto.Common.CacheAbstraction;

public class RedisCacheService : ICacheService
{
    private readonly IConnectionMultiplexer _redisConnection;
    private readonly IDatabase _database;
    private readonly string? _projectName;
    private readonly string? _env;
    private readonly string? _prefix;

    public RedisCacheService(IConnectionMultiplexer redisConnection)
    {
        _redisConnection = redisConnection;
        _database = _redisConnection.GetDatabase();
        _projectName = Assembly.GetEntryAssembly().GetName().Name;
        _env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        _prefix = $"{_projectName}-{_env}-";
    }

    public async Task<T> GetAsync<T>(string key, Func<Task<T>> fetchFromDb, TimeSpan? cacheExpiration = null ,CancellationToken cancellationToken = default)
    {
        var lockBase = $"lock-{key}";
        var lockKey = $"{_prefix}lock-{key}";
        var baseKey = $"{_prefix}{key}";
        var cacheValue = await _database.StringGetAsync(baseKey);

        if (cacheValue.IsNullOrEmpty)
        {
            if(await _database.StringSetAsync(lockKey , "1",TimeSpan.FromSeconds(10) , When.NotExists))
            {
                try
                {
                    var data = await fetchFromDb.Invoke();
                    await SetAsync(key, data, cacheExpiration, cancellationToken);

                }
                finally
                {
                    await RemoveAsync(lockBase, cancellationToken);
                    cacheValue = await _database.StringGetAsync(baseKey);
                }
            }
            else
            {
                while (await _database.KeyExistsAsync(lockKey))
                {
                    await Task.Delay(100); // Wait for the other request to populate the cache
                }
            }
        }

        return JsonConvert.DeserializeObject<T>(cacheValue);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null, CancellationToken cancellationToken = default)
    {
        key = $"{_prefix}{key}";
        var serializedValue = JsonConvert.SerializeObject(value);
         await _database.StringSetAsync(key, serializedValue, expiry);
    }

    public async Task<bool> RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        key = $"{_prefix}{key}";
        return await _database.KeyDeleteAsync(key);
    }

}

