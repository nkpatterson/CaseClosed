using Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Web.Configuration;

namespace CaseClosed.Web
{
    public partial class Startup
    {
        private static string clientId = WebConfigurationManager.AppSettings["ida:ClientId"];
        private static string aadInstance = WebConfigurationManager.AppSettings["ida:AADInstance"];
        private static string tenantId = WebConfigurationManager.AppSettings["ida:TenantId"];
        private static string postLogoutRedirectUri = WebConfigurationManager.AppSettings["ida:PostLogoutRedirectUri"];
        private static string authority = aadInstance + tenantId;

        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseCookieAuthentication(new CookieAuthenticationOptions());

            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = clientId,
                    Authority = authority,
                    PostLogoutRedirectUri = postLogoutRedirectUri
                });
        }
    }
}
