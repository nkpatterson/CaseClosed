using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using StructureMap.Configuration.DSL;

namespace CaseClosed.Core.DependencyResolution
{
    public class TelemetryRegistry : Registry
    {
        public TelemetryRegistry(string instrumentationKey)
        {
            TelemetryConfiguration.Active.InstrumentationKey = instrumentationKey;

            For<TelemetryClient>().Use(ctx => new TelemetryClient { InstrumentationKey = TelemetryConfiguration.Active.InstrumentationKey });
        }
    }
}
