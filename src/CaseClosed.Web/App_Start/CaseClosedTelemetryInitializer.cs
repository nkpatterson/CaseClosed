using System.Configuration;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

namespace CaseClosed.Web
{
    public class CaseClosedTelemetryInitializer : ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            var environment = ConfigurationManager.AppSettings["AppInsights.Environment"];
            if (!string.IsNullOrEmpty(environment))
            {
                telemetry.Context.Properties["Environment"] = environment;
            }
        }
    }
}