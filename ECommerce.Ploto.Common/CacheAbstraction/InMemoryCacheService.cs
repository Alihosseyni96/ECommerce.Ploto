using Microsoft.Extensions.Caching.Memory;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.CacheAbstraction
{
    public class InMemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        private static readonly SemaphoreSlim _cacheLock = new SemaphoreSlim(1, 1);
        public InMemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<T> GetAsync<T>(string key, Func<Task<T>> fetchFromDb, TimeSpan? cacheExpiration = null, CancellationToken cancellationToken = default)
        {
            var lockKey = $"lock:{key}";

            if(_memoryCache.TryGetValue(key , out T value))
            {
                return value;
            }

            await _cacheLock.WaitAsync(cancellationToken);

            try
            {
                T data = await fetchFromDb.Invoke();
                await SetAsync(key, data , cacheExpiration);

                return data;
            }
            finally
            {
                _cacheLock.Release();
            }


        }

        public Task SetAsync<T>(string key, T value, TimeSpan? expiry = null, CancellationToken cancellationToken = default)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiry
            };

            _memoryCache.Set(key, value, cacheEntryOptions);
            return Task.CompletedTask;
        }

        public Task<bool> RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            _memoryCache.Remove(key);
            return Task.FromResult(true);
        }

        public Task RemoveKeyPatternAsync(string pattern, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task GetKeyPatternAsync<T>(string pattern, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        Task<List<T>> ICacheService.GetKeyPatternAsync<T>(string pattern, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
