using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace CaseClosed.Web.Infrastructure
{
    public class WebApiCallerBase
    {
        public WebApiConfiguration Configuration { get; private set; }
        public string AccessToken { get; private set; }
        public HttpClient Client { get; set; }

        public WebApiCallerBase(WebApiConfiguration config)
        {
            Configuration = config;
            Client = new HttpClient { BaseAddress = new Uri(Configuration.BaseUrl) };

            var userObjectID = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value;
            var authContext = new AuthenticationContext(Configuration.Authority);
            var credential = new ClientCredential(Configuration.WebClientId, Configuration.WebClientSecret);

            // TODO: error handling here
            AccessToken = authContext.AcquireToken(Configuration.ResourceId, credential).AccessToken;
        }

        public HttpRequestMessage CreateRequest(HttpMethod method, string requestUri)
        {
            var request = new HttpRequestMessage(method, requestUri);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);

            return request;
        }
    }
}