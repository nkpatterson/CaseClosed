using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CaseClosed.Model.SmokeTests;

namespace CaseClosed.Api.Features.SmokeTests
{
    public class Create
    {
        public class Command : IAsyncRequest<SmokeTest>
        {
            public string CreatedBy { get; set; }
        }

        public class InMemoryCommandHandler : IAsyncRequestHandler<Command, SmokeTest>
        {
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

                InMemorySmokeTests.SmokeTests.Add(test);

                return test;
            }
        }
    }
}