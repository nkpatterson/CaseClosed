using System.Configuration;

namespace CaseClosed.Web.Infrastructure
{
    public class WebApiConfiguration
    {
        public string BaseUrl
        {
            get { return ConfigurationManager.AppSettings["api:BaseUrl"]; }
        }

        public string ResourceId
        {
            get { return ConfigurationManager.AppSettings["api:ResourceId"]; }
        }

        public string Authority
        {
            get { return string.Concat(ConfigurationManager.AppSettings["ida:AADInstance"], ConfigurationManager.AppSettings["ida:TenantId"]); }
        }

        public string WebClientId
        {
            get { return ConfigurationManager.AppSettings["ida:ClientId"]; }
        }

        public string WebClientSecret
        {
            get { return ConfigurationManager.AppSettings["ida:ClientSecret"]; }
        }
    }
}