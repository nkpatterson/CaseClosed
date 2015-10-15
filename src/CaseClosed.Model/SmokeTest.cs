using System;
using System.Collections.Generic;

namespace CaseClosed.Model.SmokeTests
{
    public class SmokeTest
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public bool Success { get; set; }
        public IList<string> Messages { get; set; }
    }
}
