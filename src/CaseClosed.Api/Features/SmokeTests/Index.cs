using CaseClosed.Api.Infrastructure.DAL;
using CaseClosed.Core.Caching;
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
            private ICache _cache;
            public static string CacheKey = typeof(DocDbQueryHandler).FullName;

            public DocDbQueryHandler(DocDbConfiguration config, ICache cache) : base(config)
            {
                _cache = cache;
            }

            public async Task<List<SmokeTest>> Handle(Query message)
            {
                const string cacheKey = nameof(DocDbQueryHandler);
                
                var cachedResult = _cache.Get<List<SmokeTest>>(cacheKey);
                if (cachedResult != null)
                    return cachedResult;
                
                var collection = await GetCollection();
                
                try
                {
                    var sql = $"SELECT * FROM t ORDER BY t.{message.SortBy} {message.SortDirection}";
                    var results = Client.CreateDocumentQuery<SmokeTest>(collection.SelfLink, sql).ToList();

                    _cache.Set(cacheKey, results);

                    return results;
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
        }
    }
}