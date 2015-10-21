using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Security.Claims;
using System.Web.Mvc;

namespace CaseClosed.Web.Infrastructure
{
    public class AcquireTokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var config = DependencyResolver.Current.GetService<WebApiConfiguration>();

            var userObjectID = ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier").Value;
            var authContext = new AuthenticationContext(config.Authority);
            var credential = new ClientCredential(config.WebClientId, config.WebClientSecret);
            AuthenticationResult token = authContext.AcquireToken(config.ResourceId, credential);

        }
    }
}