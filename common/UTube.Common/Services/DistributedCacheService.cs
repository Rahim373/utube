﻿using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace UTube.Common.Services
{
    /// <summary>
    /// This service manage distibuted cache using Redis
    /// </summary>
    public class DistributedCacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;

        public DistributedCacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public Task AddAsync<T>(string key, T value, CancellationToken cancellationToken = default)
        {
            return AddAsync(key, value, null, cancellationToken);
        }

        public Task AddAsync<T>(string key, T value, TimeSpan? timeSpan, CancellationToken cancellationToken = default)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = timeSpan
            };

            var str = JsonConvert.SerializeObject(value);
            return _distributedCache.SetStringAsync(key, str, options, cancellationToken);
        }

        /// <summary>
        /// Get value from Radis based on the key.
        /// </summary>
        /// <typeparam name="T?">Type of the value</typeparam>
        /// <param name="key">Key</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Value if key is found. Otherwise null</returns>
        public async ValueTask<T?> GetValueAsync<T>(string key, CancellationToken cancellationToken = default)
        {
            var str = await _distributedCache.GetStringAsync(key, cancellationToken);

            if (string.IsNullOrEmpty(str))
            {
                return default;
            }

            return JsonConvert.DeserializeObject<T>(str);
        }

        public Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            return _distributedCache.RemoveAsync(key, cancellationToken);
        }
    }
}
