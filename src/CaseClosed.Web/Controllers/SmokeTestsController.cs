using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using CaseClosed.Authorization;
using CaseClosed.SmokeTests;
using CaseClosed.SmokeTests.Dto;
using CaseClosed.Web.Models.SmokeTests;

namespace CaseClosed.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.SmokeTests)]
    public class SmokeTestsController : CaseClosedControllerBase
    {
        private readonly ISmokeTestAppService _smokeTestAppService;

        public SmokeTestsController(ISmokeTestAppService smokeTestAppService)
        {
            _smokeTestAppService = smokeTestAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _smokeTestAppService.GetAll();
            var canCreate = await PermissionChecker.IsGrantedAsync(PermissionNames.SmokeTests_Create);
            var model = new IndexViewModel
            {
                CanCreateSmokeTest = canCreate,
                Items = output
            };

            return View(model);
        }

        [AbpMvcAuthorize(PermissionNames.SmokeTests_Create)]
        public async Task<ActionResult> Create()
        {
            var output = await _smokeTestAppService.Create(new CreateSmokeTestInput());

            Flash("Smoke test created successfully!");

            return RedirectToAction("Index");
        }
    }
}