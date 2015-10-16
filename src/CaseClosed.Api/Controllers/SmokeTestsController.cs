using CaseClosed.Api.Features.SmokeTests;
using CaseClosed.Model.SmokeTests;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace CaseClosed.Api.Controllers
{
    public class SmokeTestsController : ApiController
    {
        private IMediator _mediator;

        public SmokeTestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<SmokeTest>> Get(Index.Query query)
        {
            query = query ?? new Index.Query();

            var result = await _mediator.SendAsync(query);

            return result;
        }
    }
}
