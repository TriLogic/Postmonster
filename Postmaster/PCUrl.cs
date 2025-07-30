using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Collections
{
    public class PCUrl
    {
        [JsonProperty("raw")]
        public string Raw { get; set; } = "";

        [JsonProperty("protocol")]
        public string? Protocol { get; set; }

        [JsonProperty("host")]
        public List<string>? Host { get; set; }

        [JsonProperty("path")]
        public List<string>? Path { get; set; }

        [JsonProperty("query")]
        public List<PCQueryParam>? Query { get; set; }

        [JsonProperty("variable")]
        public List<PCUrlVariable>? Variable { get; set; }
    }

    public class PCQueryParam
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

    public class PCUrlVariable
    {
        [JsonProperty("key")]
        public string Key { get; set; } = "";

        [JsonProperty("value")]
        public string Value { get; set; } = "";
    }
}
