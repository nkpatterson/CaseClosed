using CaseClosed.Api.Infrastructure.DAL;
using CaseClosed.Core.Caching;
using CaseClosed.Model;
using MediatR;
using System.Linq;
using System.Threading.Tasks;

namespace CaseClosed.Api.Features.AppConfig
{
    public class Update
    {
        public class Command : IAsyncRequest<AppConfiguration>
        {
            public AppConfiguration AppConfiguration { get; set; }
        }

        public class CommandHandler : IAsyncRequestHandler<Command, AppConfiguration>
        {
            private IDocumentClient _client;
            private ICache _cache;

            public CommandHandler(IDocumentClient client, ICache cache)
            {
                _client = client;
                _cache = cache;
            }

            public async Task<AppConfiguration> Handle(Command message)
            {
                var sql = "SELECT * FROM ac";
                var query = await _client.CreateDocumentQueryAsync<AppConfiguration>(sql);
                var currentConfig = query.FirstOrDefault();

                if (currentConfig == null)
                    currentConfig = new AppConfiguration();

                currentConfig.CurrentVersion = message.AppConfiguration.CurrentVersion;
                currentConfig.BetaVersion = message.AppConfiguration.BetaVersion;
                currentConfig.BetaUrl = message.AppConfiguration.BetaUrl;

                await _client.UpdateDocumentAsync(currentConfig);

                _cache.Clear(Index.QueryHandler.CacheKey);

                return currentConfig;
            }
        }
    }
}