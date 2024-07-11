using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;

namespace ECommerce.Ploto.Common.CacheAbstraction;

public class RedisCacheService : ICacheService
{
    private readonly IConnectionMultiplexer _redisConnection;
    private readonly IDatabase _database;

    public RedisCacheService(IConnectionMultiplexer redisConnection)
    {
        _redisConnection = redisConnection;
        _database = _redisConnection.GetDatabase();
    }

    public async Task<T> GetAsync<T>(string key, Func<Task<T>> fetchFromDb, TimeSpan cacheExpiration ,CancellationToken cancellationToken = default)
    {
        var lockKey = $"lock:{key}";
        var cacheValue = await _database.StringGetAsync(key);

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
                    await RemoveAsync(lockKey , cancellationToken);
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
        var serializedValue = JsonConvert.SerializeObject(value);
         await _database.StringSetAsync(key, serializedValue, expiry);
    }

    public async Task<bool> RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        return await _database.KeyDeleteAsync(key);
    }
}

