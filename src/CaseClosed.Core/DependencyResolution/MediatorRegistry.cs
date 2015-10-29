using MediatR;
using StructureMap.Configuration.DSL;
using System.Reflection;

namespace CaseClosed.Core.DependencyResolution
{
    public class MediatorRegistry : Registry
    {

        public MediatorRegistry(Assembly assemblyToScan)
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
        }
    }
}