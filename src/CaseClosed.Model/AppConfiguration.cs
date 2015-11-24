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
    }
}
