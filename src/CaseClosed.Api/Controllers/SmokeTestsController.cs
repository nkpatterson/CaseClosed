using CaseClosed.Api.Features.SmokeTests;
using CaseClosed.Model.SmokeTests;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;

namespace CaseClosed.Api.Controllers
{
    //[Authorize]
    public class SmokeTestsController : ApiController
    {
        private IMediator _mediator;

        public SmokeTestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IHttpActionResult> Get(Index.Query query)
        {
            query = query ?? new Index.Query();

            var result = await _mediator.SendAsync(query);

            return Ok(result);
        }

        public async Task<IHttpActionResult> Post(Create.Command command)
        {
            var result = await _mediator.SendAsync(command);

            return Ok(result);
        }
    }
}
