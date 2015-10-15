using CaseClosed.Model.SmokeTests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace CaseClosed.Api.Features.SmokeTests
{
    public class Index
    {
        public class Query : IAsyncRequest<List<SmokeTest>>
        {
        }

        public class QueryHandler : IAsyncRequestHandler<Query, List<SmokeTest>>
        {
            public Task<List<SmokeTest>> Handle(Query message)
            {
                return null;
            }
        }
    }
}