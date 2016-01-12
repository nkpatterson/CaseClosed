using CaseClosed.Api.Controllers;
using CaseClosed.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security.Twitter;
using Owin;
using System;
using System.Configuration;
using System.Globalization;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Startup))]

namespace CaseClosed.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseOAuthBearerAuthentication(AccountController.OAuthBearerOptions);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            if (IsTrue("ExternalAuth.Facebook.IsEnabled"))
            {
                app.UseFacebookAuthentication(CreateFacebookAuthOptions());
            }

            if (IsTrue("ExternalAuth.Twitter.IsEnabled"))
            {
                app.UseTwitterAuthentication(CreateTwitterAuthOptions()); 
            }

            if (IsTrue("ExternalAuth.Google.IsEnabled"))
            {
                app.UseGoogleAuthentication(CreateGoogleAuthOptions());
            }

            if (IsTrue("ExternalAuth.OpenIdConnect.IsEnabled"))
            {
                app.UseOpenIdConnectAuthentication(CreateOpenIdAuthOptions());
            }
        }

        private static OpenIdConnectAuthenticationOptions CreateOpenIdAuthOptions()
        {
            var clientId = ConfigurationManager.AppSettings["ExternalAuth.OpenIdConnect.ClientId"];
            var aadInstance = ConfigurationManager.AppSettings["ExternalAuth.OpenIdConnect.AADInstance"];
            var tenant = ConfigurationManager.AppSettings["ExternalAuth.OpenIdConnect.Tenant"];
            var logoutRedirectUrl = ConfigurationManager.AppSettings["ExternalAuth.OpenIdConnect.PostLogoutRedirectUrl"];
            var authority = string.Format(CultureInfo.InvariantCulture, aadInstance, tenant);

            return new OpenIdConnectAuthenticationOptions
            {
                ClientId = clientId,
                Authority = authority,
                PostLogoutRedirectUri = logoutRedirectUrl,
                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    AuthenticationFailed = context =>
                    {
                        context.HandleResponse();
                        context.Response.Redirect("/Error/ShowError?signIn=true&errorMessage=" + context.Exception.Message);
                        return Task.FromResult(0);
                    }
                }
            };
        }

        private static FacebookAuthenticationOptions CreateFacebookAuthOptions()
        {
            var options = new FacebookAuthenticationOptions
            {
                AppId = ConfigurationManager.AppSettings["ExternalAuth.Facebook.AppId"],
                AppSecret = ConfigurationManager.AppSettings["ExternalAuth.Facebook.AppSecret"]
            };

            options.Scope.Add("email");
            options.Scope.Add("public_profile");

            return options;
        }

        private static TwitterAuthenticationOptions CreateTwitterAuthOptions()
        {
            return new TwitterAuthenticationOptions
            {
                ConsumerKey = ConfigurationManager.AppSettings["ExternalAuth.Twitter.ConsumerKey"],
                ConsumerSecret = ConfigurationManager.AppSettings["ExternalAuth.Twitter.ConsumerSecret"]
            };
        }

        private static GoogleOAuth2AuthenticationOptions CreateGoogleAuthOptions()
        {
            return new GoogleOAuth2AuthenticationOptions
            {
                ClientId = ConfigurationManager.AppSettings["ExternalAuth.Google.ClientId"],
                ClientSecret = ConfigurationManager.AppSettings["ExternalAuth.Google.ClientSecret"]
            };
        }

        private static bool IsTrue(string appSettingName)
        {
            return string.Equals(
                ConfigurationManager.AppSettings[appSettingName],
                "true",
                StringComparison.InvariantCultureIgnoreCase);
        }
    }
}