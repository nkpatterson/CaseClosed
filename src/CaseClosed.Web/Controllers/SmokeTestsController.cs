using CaseClosed.Web.Features.SmokeTests;
using CaseClosed.Web.Infrastructure;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CaseClosed.Web.Controllers
{
    [Authorize, AcquireToken]
    public class SmokeTestsController : CaseClosedController
    {
        // GET: SmokeTests
        public async Task<ActionResult> Index(Index.Query query)
        {
            var result = await Mediator.SendAsync(query);

            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Create.Command command)
        {
            var result = await Mediator.SendAsync(command);

            Flash("Smoke Test was successful!");

            return RedirectToAction("Index");
        }
    }
}