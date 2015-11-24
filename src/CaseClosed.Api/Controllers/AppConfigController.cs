using CaseClosed.Api.Features.AppConfig;
using MediatR;
using System.Threading.Tasks;
using System.Web.Http;

namespace CaseClosed.Api.Controllers
{
    //[Authorize]
    public class AppConfigController : ApiController
    {
        private IMediator _mediator;

        public AppConfigController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IHttpActionResult> Get(Index.Query query)
        {
            query = query ?? new Index.Query();

            var result = await _mediator.SendAsync(query);

            return Ok(result);
        }

        public async Task<IHttpActionResult> Post(Update.Command command)
        {
            var result = await _mediator.SendAsync(command);

            return Ok(result);
        }
    }
}
