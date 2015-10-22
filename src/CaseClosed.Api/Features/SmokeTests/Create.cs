using CaseClosed.Api.Infrastructure.DAL;
using CaseClosed.Model.SmokeTests;
using MediatR;
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
            public DocDbCommandHandler(DocDbConfiguration config) : base(config)
            {
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

                try
                {
                    await Client.CreateDocumentAsync(collection.SelfLink, test);
                }
                catch (Exception exc)
                {
                    throw exc;
                }

                return test;
            }
        }
    }
}