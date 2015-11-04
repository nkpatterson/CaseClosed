using System.Web.Configuration;

namespace CaseClosed.Api.Infrastructure.DAL
{
    public class DocDbConfiguration
    {
        public string EndpointUrl { get; set; } = WebConfigurationManager.AppSettings["docdb:EndpointUrl"];

        public string AuthorizationKey { get; set; } = WebConfigurationManager.AppSettings["docdb:AuthorizationKey"];

        public string DatabaseId { get; set; } = WebConfigurationManager.AppSettings["docdb:DatabaseId"];

        public string CollectionId { get; set; } = WebConfigurationManager.AppSettings["docdb:CollectionId"];
    }
}