using CaseClosed.Model.SmokeTests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseClosed.Web.Features.SmokeTests
{
    public class Create
    {
        public class Command : IRequest<SmokeTest>
        {
            public string CreatedBy { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, SmokeTest>
        {
            public SmokeTest Handle(Command message)
            {
                var test = new SmokeTest
                {
                    Id = Guid.NewGuid().ToString(),
                    Created = DateTime.UtcNow,
                    CreatedBy = message.CreatedBy,
                    Success = true,
                    Messages = new[] { "Works from the web!" }
                };

                InMemorySmokeTests.Tests.Add(test);

                return test;
            }
        }
    }
}