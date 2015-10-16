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
            private static List<SmokeTest> _tests = new List<SmokeTest>
            {
                new SmokeTest { Id = Guid.NewGuid().ToString(), Created = DateTime.UtcNow, CreatedBy = "nkpatterson", Success = true }
            };

            public async Task<List<SmokeTest>> Handle(Query message)
            {
                return _tests.OrderByDescending(x => x.Created).ToList();
            }
        }
    }
}