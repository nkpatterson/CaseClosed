using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace CaseClosed.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : CaseClosedControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}