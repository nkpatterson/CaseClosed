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
            public string CurrentVersion { get; set; }
            public string BetaVersion { get; set; }
            public string BetaUrl { get; set; }
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
                var currentConfig = query.ToList().FirstOrDefault();

                if (currentConfig == null)
                    currentConfig = new AppConfiguration();

                currentConfig.CurrentVersion = message.CurrentVersion;
                currentConfig.BetaVersion = message.BetaVersion;
                currentConfig.BetaUrl = message.BetaUrl;

                await _client.UpdateDocumentAsync(currentConfig);

                _cache.Clear(Index.QueryHandler.CacheKey);

                return currentConfig;
            }
        }
    }
}