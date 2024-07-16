using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.CacheAbstraction.Configurations
{
    public static class CacheServiceCollectionExtensions
    {
        public static IServiceCollection AddCacheAbstraction(this IServiceCollection services, Action<CacheConfig> cacheConfig)
        {
            var config = new CacheConfig(services);
            cacheConfig(config);
            return services;
        }

        public class CacheConfig
        {
            private readonly IServiceCollection _services;

            public CacheConfig(IServiceCollection services)
            {
                _services = services;
            }

            public CacheConfig UseInMemoryCache()
            {
                _services.AddMemoryCache();
                _services.AddSingleton<ICacheService, InMemoryCacheService>();
                return this;
            }

            public CacheConfig UseRedisCache(Action<RedisCacheOptions> action)
            {
                var redisOptions = new RedisCacheOptions();
                action(redisOptions);

                _services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisOptions.ConnectionString));
                _services.AddSingleton<ICacheService, RedisCacheService>();
                return this;
            }
        }
    }
}
