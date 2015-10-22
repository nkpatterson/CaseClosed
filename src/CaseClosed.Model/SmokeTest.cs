using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CaseClosed.Model.SmokeTests
{
    public class SmokeTest
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public bool Success { get; set; }
        public IList<string> Messages { get; set; }
    }
}
