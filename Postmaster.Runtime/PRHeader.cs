using Newtonsoft.Json;

namespace Postmonster.Runtime
{
    public class PRHeader : IPRKeyedValue
    {
        public string key { get; set; } = "";
        public string value { get; set; } = "";

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? description { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? disabled { get; set; }
    }
}
