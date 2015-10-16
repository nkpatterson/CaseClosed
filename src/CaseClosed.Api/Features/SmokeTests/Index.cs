using CaseClosed.Model.SmokeTests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseClosed.Api.Features.SmokeTests
{
    public class Index
    {
        public class Query : IAsyncRequest<List<SmokeTest>>
        {
            public string SortBy { get; set; }
            public string SortDirection { get; set; }
            public int? Page { get; set; }
        }

        //public class DocDbQueryHandler : IAsyncRequestHandler<Query, List<SmokeTest>>
        //{
        //    public Task<List<SmokeTest>> Handle(Query message)
        //    {
        //        return null;
        //    }
        //}

        public class InMemoryQueryHandler : IAsyncRequestHandler<Query, List<SmokeTest>>
        {
            public async Task<List<SmokeTest>> Handle(Query message)
            {
                return InMemorySmokeTests.SmokeTests.OrderByDescending(x => x.Created).ToList();
            }
        }
    }
}