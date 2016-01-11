using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using CaseClosed.Authorization;
using CaseClosed.MultiTenancy;

namespace CaseClosed.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : CaseClosedControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}