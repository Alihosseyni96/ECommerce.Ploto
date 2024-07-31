using ECommerce.Ploto.Common.CacheAbstraction.Configurations;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System.Reflection;

namespace ECommerce.Ploto.Common.CacheAbstraction;

public class RedisCacheService : ICacheService
{
    private readonly IConnectionMultiplexer _redisConnection;
    private readonly IDatabase _database;
    private readonly RedisCacheOptions _redisOptions;

    public RedisCacheService(IConnectionMultiplexer redisConnection, RedisCacheOptions redisOptions)
    {
        _redisConnection = redisConnection;
        _database = _redisConnection.GetDatabase();
        _redisOptions = redisOptions;
    }

    public async Task<T> GetAsync<T>(string key, Func<Task<T>> fetchFromDb, TimeSpan? cacheExpiration = null, CancellationToken cancellationToken = default)
    {
        var lockBase = $"lock-{key}";
        var lockKey = $"{_redisOptions.Prefix}lock-{key}";
        var baseKey = $"{_redisOptions.Prefix}{key}";

        var cacheValue = await _database.StringGetAsync(baseKey);

        if (cacheValue.IsNullOrEmpty)
        {
            if (await _database.StringSetAsync(lockKey, "1", TimeSpan.FromSeconds(10), When.NotExists))
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
        key = $"{_redisOptions.Prefix}{key}";
        var serializedValue = JsonConvert.SerializeObject(value);
        await _database.StringSetAsync(key, serializedValue, expiry);
    }

    public async Task<bool> RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        key = $"{_redisOptions.Prefix}{key}";
        return await _database.KeyDeleteAsync(key);
    }

    public async Task RemoveKeyPatternAsync(string pattern, CancellationToken cancellationToken = default)
    {
        pattern = $"*{_redisOptions.Prefix}{pattern}";
        var server = _redisConnection.GetServer($"{_redisOptions.Host}:{_redisOptions.Port}");
        var kyes = server.Keys(pattern: pattern).ToArray();
        await _database.KeyDeleteAsync(kyes);
    }

    public async Task<List<T>> GetKeyPatternAsync<T>(string pattern, CancellationToken cancellationToken = default)
    {
        pattern = $"*{_redisOptions.Prefix}{pattern}";
        var server = _redisConnection.GetServer($"{_redisOptions.Host}:{_redisOptions.Port}");
        var kyes = server.Keys(pattern: pattern).ToArray();
        var value   = await _database.StringGetAsync(kyes);
        var result = value.Select(d => System.Text.Json.JsonSerializer.Deserialize<T>(d)).ToList();
        return result;  
    }

}

