using System.Web.Mvc;
using Abp.IdentityFramework;
using Abp.UI;
using Abp.Web.Mvc.Controllers;
using BrockAllen.CookieTempData;
using CaseClosed.Web.Models.Layout;
using Microsoft.AspNet.Identity;

namespace CaseClosed.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class CaseClosedControllerBase : AbpController
    {
        protected CaseClosedControllerBase()
        {
            LocalizationSourceName = CaseClosedConsts.LocalizationSourceName;
        }

        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException(L("FormIsNotValidMessage"));
            }
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        protected override ITempDataProvider CreateTempDataProvider()
        {
            return new CookieTempDataProvider();
        }

        protected void Flash(string message, FlashMessageType type = FlashMessageType.Success)
        {
            TempData["Flash"] = new FlashViewModel
            {
                Message = message,
                MessageType = type
            };
        }
    }
}