using Newtonsoft.Json;

namespace Postmonster.Runtime
{
    public class PRUrlEncodedField
    {
        [JsonProperty("key")]
        public string Key { get; set; } = "";

        [JsonProperty("value")]
        public string Value { get; set; } = "";

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("disabled")]
        public bool? Disabled { get; set; }
    }
}
