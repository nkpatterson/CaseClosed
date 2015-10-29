using CaseClosed.Core.Caching;
using StackExchange.Redis;
using StructureMap.Configuration.DSL;
using System;

namespace CaseClosed.Core.DependencyResolution
{
    public class CachingRegistry : Registry
    {
        private static string CacheConnectionString;

        public CachingRegistry(string cacheConnectionString, bool isEnabled)
        {
            CacheConnectionString = cacheConnectionString;

            if (isEnabled)
            {
                For<ICache>().Use<RedisCache>();
                For<IDatabase>().Use(ctx => CacheConnection.GetDatabase(-1, null));
            }
            else
                For<ICache>().Use<DisabledCache>();
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect(CacheConnectionString);
        });

        public static ConnectionMultiplexer CacheConnection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
