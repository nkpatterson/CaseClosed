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

        public class CommandHandler : IAsyncRequestHandler<Command, SmokeTest>
        {
            private IDocumentClient _client;
            private ICache _cache;
            private TelemetryClient _telemetry;

            public CommandHandler(IDocumentClient client, ICache cache, TelemetryClient telemetry)
            {
                _client = client;
                _cache = cache;
                _telemetry = telemetry;
            }

            public async Task<SmokeTest> Handle(Command message)
            {
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
                    await _client.CreateDocumentAsync(test);

                    _cache.Clear(Index.QueryHandler.CacheKey);
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