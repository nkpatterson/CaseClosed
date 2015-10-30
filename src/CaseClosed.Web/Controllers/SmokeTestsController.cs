using CaseClosed.Web.Features.SmokeTests;
using CaseClosed.Web.Infrastructure;
using CaseClosed.Web.Models;
using MediatR;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CaseClosed.Web.Controllers
{
    [Authorize, AcquireToken]
    public class SmokeTestsController : Controller
    {
        private IMediator _mediator;

        public SmokeTestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: SmokeTests
        public async Task<ActionResult> Index(Index.Query query)
        {
            var result = await _mediator.SendAsync(query);

            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Create.Command command)
        {
            var result = await _mediator.SendAsync(command);

            TempData.Add("Flash", new FlashMessage { Message = "Smoke Test was successful!", MessageType = FlashMessageType.Success });

            return RedirectToAction("Index");
        }
    }
}