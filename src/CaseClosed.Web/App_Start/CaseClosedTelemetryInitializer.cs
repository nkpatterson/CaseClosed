using System.Configuration;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

namespace CaseClosed.Web.App_Start
{
    public class CaseClosedTelemetryInitializer : ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            var appId = ConfigurationManager.AppSettings["AppInsights.AppIdentifier"];
            if (!string.IsNullOrEmpty(appId))
            {
                telemetry.Context.Properties["AppIdentifier"] = appId;
            }
        }
    }
}