using CaseClosed.Core.Caching;
using MediatR;
using StackExchange.Redis;
using StructureMap.Configuration.DSL;
using System;
using System.Configuration;
using System.Reflection;

namespace CaseClosed.Core.DependencyResolution
{
    public class CoreRegistry : Registry
    {
        public CoreRegistry(Assembly assemblyToScan)
        {
            Scan(scan =>
            {
                scan.AssemblyContainingType<IMediator>();
                scan.Assembly(assemblyToScan);

                scan.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                scan.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>));
                scan.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                scan.ConnectImplementationsToTypesClosing(typeof(IAsyncNotificationHandler<>));

                scan.WithDefaultConventions();
            });

            For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
            For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));
            For<IMediator>().Use<Mediator>();
            For<ICache>().Use<RedisCache>();
            For<IDatabase>().Use(ctx => CacheConnection.GetDatabase(-1, null));
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect(ConfigurationManager.AppSettings["cache:ConnectionString"]);
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