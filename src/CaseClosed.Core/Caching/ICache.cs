using System;

namespace CaseClosed.Core.Caching
{
    public interface ICache
    {
        T Get<T>(string key);
        void Set<T>(string key, T value, TimeSpan? expiry = null);
        bool IsInCache(string key);
        void Clear(string key);
    }
}
