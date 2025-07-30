using Newtonsoft.Json;

namespace Postmonster.Runtime
{
    public class PRCookie : IPRKeyedValueLike
    {
        public string name { get; set; } = string.Empty;

        public string? value { get; set; } = string.Empty;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? domain { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? path { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? expires { get; set; } // ISO 8601 string or timestamp

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? httpOnly { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? secure { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? session { get; set; }
    }
}
