using System;

namespace CaseClosed.Core.Caching
{
    public class DisabledCache : ICache
    {
        public void Clear(string key)
        {
        }

        public T Get<T>(string key)
        {
            return default(T);
        }

        public bool IsInCache(string key)
        {
            return false;
        }

        public void Set<T>(string key, T value, TimeSpan? expiry = default(TimeSpan?))
        {
        }
    }
}
