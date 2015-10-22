using System.Configuration;

namespace CaseClosed.Api.Infrastructure
{
    public class DocDbConfiguration
    {
        public string EndpointUrl
        {
            get { return ConfigurationManager.AppSettings["docdb:EndpointUrl"]; }
        }

        public string AuthorizationKey
        {
            get { return ConfigurationManager.AppSettings["docdb:AuthorizationKey"]; }
        }

        public string DatabaseId
        {
            get { return ConfigurationManager.AppSettings["docdb:DatabaseId"]; }
        }

        public string CollectionId
        {
            get { return ConfigurationManager.AppSettings["docdb:CollectionId"]; }
        }
    }
}