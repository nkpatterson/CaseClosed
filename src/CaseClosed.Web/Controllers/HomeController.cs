using System.Web.Mvc;

namespace CaseClosed.Web.Controllers
{
    public class HomeController : CaseClosedControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}