using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CaseClosed.Model.SmokeTests;

namespace CaseClosed.Api.Features.SmokeTests
{
    public class Create
    {
        public class Command : IAsyncRequest
        {
            public string CreatedBy { get; set; }
        }

        public class InMemoryCommandHandler : AsyncRequestHandler<Command>
        {
            protected override async Task HandleCore(Command message)
            {
                var test = new SmokeTest
                {
                    Id = Guid.NewGuid().ToString(),
                    Created = DateTime.UtcNow,
                    CreatedBy = message.CreatedBy,
                    Success = true,
                    Messages = new List<string> { "It works!" }
                };

                InMemorySmokeTests.SmokeTests.Add(test);
            }
        }
    }
}