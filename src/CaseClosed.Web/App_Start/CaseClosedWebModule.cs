using System.Reflection;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Abp.Modules;
using Abp.Web.Mvc;
using Abp.Zero.Configuration;
using CaseClosed.Api;
using Microsoft.ApplicationInsights.Extensibility;

namespace CaseClosed.Web
{
    [DependsOn(
        typeof(CaseClosedDataModule), 
        typeof(CaseClosedApplicationModule), 
        typeof(CaseClosedWebApiModule),
        typeof(AbpWebMvcModule))]
    public class CaseClosedWebModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Enable database based localization
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            //Configure navigation/menu
            Configuration.Navigation.Providers.Add<CaseClosedNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            TelemetryConfiguration.Active.InstrumentationKey = WebConfigurationManager.AppSettings["AppInsights.InstrumentationKey"];
        }
    }
}
