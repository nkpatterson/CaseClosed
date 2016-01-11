using System.Web.Mvc;

namespace CaseClosed.Web.Controllers
{
    public class AboutController : CaseClosedControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}