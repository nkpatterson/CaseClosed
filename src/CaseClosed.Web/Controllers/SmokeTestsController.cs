using CaseClosed.Web.Features.SmokeTests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CaseClosed.Web.Controllers
{
    [Authorize]
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
        public ActionResult Create(Create.Command command)
        {
            var result = _mediator.Send(command);

            return RedirectToAction("Index");
        }
    }
}