using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Ploto.Common.CacheAbstraction
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(string key, Func<Task<T>> fetchFromDb, TimeSpan? cacheExpiration = null, CancellationToken cancellationToken = default);
        Task SetAsync<T>(string key, T value, TimeSpan? expiry = null, CancellationToken cancellationToken = default);
        Task<bool> RemoveAsync(string key, CancellationToken cancellationToken = default);
        /// <summary>
        /// pattern like => key:*
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task RemoveKeyPatternAsync(string pattern, CancellationToken cancellationToken = default);
    }
}
