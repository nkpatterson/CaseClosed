using System.Web.Configuration;

namespace CaseClosed.Web.Infrastructure
{
    public class WebApiConfiguration
    {
        public string BaseUrl
        {
            get { return WebConfigurationManager.AppSettings["api:BaseUrl"]; }
        }

        public string ResourceId
        {
            get { return WebConfigurationManager.AppSettings["api:ResourceId"]; }
        }

        public string Authority
        {
            get { return string.Concat(WebConfigurationManager.AppSettings["ida:AADInstance"], WebConfigurationManager.AppSettings["ida:TenantId"]); }
        }

        public string WebClientId
        {
            get { return WebConfigurationManager.AppSettings["ida:ClientId"]; }
        }

        public string WebClientSecret
        {
            get { return WebConfigurationManager.AppSettings["ida:ClientSecret"]; }
        }
    }
}