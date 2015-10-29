using Newtonsoft.Json;
using StackExchange.Redis;
using System;

namespace CaseClosed.Core.Caching
{
    public class RedisCache : ICache
    {
        private IDatabase _cache;

        public RedisCache(IDatabase cache)
        {
            _cache = cache;
        }

        public void Clear(string key)
        {
            _cache.StringSet(key, RedisValue.Null);
        }

        public T Get<T>(string key)
        {
            var cachedResult = _cache.StringGet(key);
            if (cachedResult.HasValue)
                return JsonConvert.DeserializeObject<T>(cachedResult);

            return default(T);
        }

        public bool IsInCache(string key)
        {
            return _cache.StringGet(key).HasValue;
        }

        public void Set<T>(string key, T value, TimeSpan? expiry = null)
        {
            _cache.StringSet(key, JsonConvert.SerializeObject(value));

            if (expiry != null)
                _cache.KeyExpire(key, expiry);
        }
    }
}
