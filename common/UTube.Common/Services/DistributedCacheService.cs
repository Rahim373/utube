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
            return AddAsync(key, JsonConvert.SerializeObject(value), cancellationToken);
        }

        public Task AddAsync<T>(string key, T value, TimeSpan? timeSpan, CancellationToken cancellationToken = default)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = timeSpan
            };

            return _distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(value), options, cancellationToken);
        }

        public async ValueTask<T?> GetValueAsync<T>(string key, CancellationToken cancellationToken = default)
        {
            var str = await _distributedCache.GetStringAsync(key, cancellationToken);

            if (str is null)
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