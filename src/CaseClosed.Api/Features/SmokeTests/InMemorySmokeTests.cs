using CaseClosed.Model.SmokeTests;
using System;
using System.Collections.Generic;

namespace CaseClosed.Api.Features.SmokeTests
{
    public static class InMemorySmokeTests
    {
        public static List<SmokeTest> SmokeTests = new List<SmokeTest>
        {
            new SmokeTest { Id = Guid.NewGuid().ToString(), Created = DateTime.UtcNow, CreatedBy = "nkpatterson", Success = true }
        };
    }
}