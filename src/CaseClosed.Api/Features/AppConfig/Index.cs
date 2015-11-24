using CaseClosed.Api.Infrastructure.DAL;
using CaseClosed.Core.Caching;
using CaseClosed.Model;
using MediatR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CaseClosed.Api.Features.AppConfig
{
    public class Index
    {
        public class Query : IAsyncRequest<AppConfiguration>
        {

        }

        public class QueryHandler : IAsyncRequestHandler<Query, AppConfiguration>
        {
            private IDocumentClient _client;
            private ICache _cache;
            public static readonly string CacheKey = typeof(QueryHandler).FullName;

            public QueryHandler(IDocumentClient client, ICache cache)
            {
                _client = client;
                _cache = cache;
            }

            public async Task<AppConfiguration> Handle(Query message)
            {
                var cachedResult = _cache.Get<AppConfiguration>(CacheKey);
                if (cachedResult != null)
                    return cachedResult;

                var sql = "SELECT * FROM ac";
                var query = await _client.CreateDocumentQueryAsync<AppConfiguration>(sql);
                var config = query.FirstOrDefault();

                _cache.Set(CacheKey, config, TimeSpan.FromMinutes(5));

                return config;
            }
        }

    }
}