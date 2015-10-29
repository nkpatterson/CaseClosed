using System.Web.Configuration;

namespace CaseClosed.Api.Infrastructure.DAL
{
    public class DocDbConfiguration
    {
        public string EndpointUrl
        {
            get { return WebConfigurationManager.AppSettings["docdb:EndpointUrl"]; }
        }

        public string AuthorizationKey
        {
            get { return WebConfigurationManager.AppSettings["docdb:AuthorizationKey"]; }
        }

        public string DatabaseId
        {
            get { return WebConfigurationManager.AppSettings["docdb:DatabaseId"]; }
        }

        public string CollectionId
        {
            get { return WebConfigurationManager.AppSettings["docdb:CollectionId"]; }
        }
    }
}