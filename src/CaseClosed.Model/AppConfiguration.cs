using System;
using Newtonsoft.Json;

namespace CaseClosed.Model
{
    public class AppConfiguration
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        public string CurrentVersion { get; set; }
        public string BetaVersion { get; set; }
        public string BetaUrl { get; set; }

        public bool IsBetaAvailable(string currentUrl)
        {
            if (string.IsNullOrEmpty(BetaUrl)) return false;
            if (currentUrl.Equals(BetaUrl, StringComparison.InvariantCultureIgnoreCase)) return false;
            if (!currentUrl.Equals(BetaUrl, StringComparison.InvariantCultureIgnoreCase)) return true;

            return false;
        }
    }
}
