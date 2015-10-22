using CaseClosed.Api.Infrastructure;
using CaseClosed.Model.SmokeTests;
using MediatR;
using Microsoft.Azure.Documents.Linq;
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
            public string SortBy { get; set; } = "Created";
            public string SortDirection { get; set; } = "DESC";
            public int Page { get; set; } = 1;
        }

        public class DocDbQueryHandler : DocDbHandlerBase, IAsyncRequestHandler<Query, List<SmokeTest>>
        {
            public DocDbQueryHandler(DocDbConfiguration config) : base(config)
            {
            }

            public async Task<List<SmokeTest>> Handle(Query message)
            {
                var collection = await GetCollection();
                
                try
                {
                    var sql = $"SELECT * FROM t ORDER BY t.{message.SortBy} {message.SortDirection}";
                    var results = Client.CreateDocumentQuery<SmokeTest>(collection.SelfLink, sql).ToList();

                    return results;
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
        }

        public class InMemoryQueryHandler// : IAsyncRequestHandler<Query, List<SmokeTest>>
        {
            public async Task<List<SmokeTest>> Handle(Query message)
            {
                return InMemorySmokeTests.SmokeTests.OrderByDescending(x => x.Created).ToList();
            }
        }
    }
}