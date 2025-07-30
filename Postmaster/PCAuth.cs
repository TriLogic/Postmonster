using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Collections
{
    public class PCAuth
    {
        [JsonProperty("type")]
        public string Type { get; set; } = ""; // e.g., "apikey", "bearer", "basic", etc.

        [JsonProperty("apikey")]
        public List<PCAuthParam>? ApiKey { get; set; }

        [JsonProperty("bearer")]
        public List<PCAuthParam>? Bearer { get; set; }

        [JsonProperty("basic")]
        public List<PCAuthParam>? Basic { get; set; }

        [JsonProperty("oauth2")]
        public List<PCAuthParam>? OAuth2 { get; set; }

        // Add other auth types as needed
    }

    public class PCAuthParam
    {
        [JsonProperty("key")]
        public string Key { get; set; } = "";

        [JsonProperty("value")]
        public string Value { get; set; } = "";

        [JsonProperty("type")]
        public string? Type { get; set; } // "string", etc.
    }
}
