using CaseClosed.Model.SmokeTests;
using System;
using System.Collections.Generic;

namespace CaseClosed.Web.Features.SmokeTests
{
    public static class InMemorySmokeTests
    {
        public static List<SmokeTest> Tests = new List<SmokeTest>
                    {
                        new SmokeTest { Id = Guid.NewGuid().ToString(), Created = DateTime.UtcNow, CreatedBy = "nkpatterson", Success = false },
                        new SmokeTest { Id = Guid.NewGuid().ToString(), Created = DateTime.UtcNow.AddDays(-1), CreatedBy = "nkpatterson", Success = true }
                    };
    }
}