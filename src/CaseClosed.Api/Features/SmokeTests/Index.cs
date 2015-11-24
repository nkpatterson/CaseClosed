using CaseClosed.Api.Infrastructure.DAL;
using CaseClosed.Core.Caching;
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
            public string SortBy { get; set; } = "Created";
            public string SortDirection { get; set; } = "DESC";
            public int Page { get; set; } = 1;
        }

        public class QueryHandler : IAsyncRequestHandler<Query, List<SmokeTest>>
        {
            private ICache _cache;
            private IDocumentClient _client;
            public static readonly string CacheKey = typeof(QueryHandler).FullName;

            public QueryHandler(IDocumentClient client, ICache cache)
            {
                _client = client;
                _cache = cache;
            }

            public async Task<List<SmokeTest>> Handle(Query message)
            {
                var cachedResult = _cache.Get<List<SmokeTest>>(CacheKey);
                if (cachedResult != null)
                    return cachedResult;

                try
                {
                    var sql = $"SELECT * FROM t ORDER BY t.{message.SortBy} {message.SortDirection}";
                    var results = await _client.CreateDocumentQueryAsync<SmokeTest>(sql);
                    var resultsList = results.ToList();

                    _cache.Set(CacheKey, resultsList, TimeSpan.FromMinutes(1));

                    return resultsList;
                }
                catch (Exception exc)
                {
                    throw exc;
                }
            }
        }
    }
}