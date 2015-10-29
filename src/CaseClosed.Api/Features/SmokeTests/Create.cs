using CaseClosed.Api.Infrastructure.DAL;
using CaseClosed.Core.Caching;
using CaseClosed.Model.SmokeTests;
using MediatR;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseClosed.Api.Features.SmokeTests
{
    public class Create
    {
        public class Command : IAsyncRequest<SmokeTest>
        {
            public string CreatedBy { get; set; }
        }

        public class DocDbCommandHandler : DocDbHandlerBase, IAsyncRequestHandler<Command, SmokeTest>
        {
            private TelemetryClient _telemetry;
            private ICache _cache;

            public DocDbCommandHandler(DocDbConfiguration config, TelemetryClient telemetry, ICache cache) : base(config)
            {
                _telemetry = telemetry;
                _cache = cache;
            }

            public async Task<SmokeTest> Handle(Command message)
            {
                var collection = await GetCollection();
                var test = new SmokeTest
                {
                    Id = Guid.NewGuid().ToString(),
                    Created = DateTime.UtcNow,
                    CreatedBy = message.CreatedBy,
                    Success = true,
                    Messages = new List<string> { "It works!" }
                };

                var evt = new EventTelemetry
                {
                    Name = "Smoke Test",
                    Timestamp = DateTimeOffset.Now
                };
                evt.Properties.Add("CreatedBy", message.CreatedBy);

                try
                {
                    await Client.CreateDocumentAsync(collection.SelfLink, test);

                    evt.Properties.Add("Success", "True");

                    _cache.Clear(Index.DocDbQueryHandler.CacheKey);
                }
                catch (Exception exc)
                {
                    evt.Properties.Add("Success", "False");
                    _telemetry.TrackException(exc);
                    throw exc;
                }
                finally
                {
                    _telemetry.TrackEvent(evt);
                }

                return test;
            }
        }
    }
}