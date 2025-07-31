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
        public string Type { get; set; } = "";

        [JsonProperty("apikey")]
        public PCAuthParamList? ApiKey { get; set; }

        [JsonProperty("bearer")]
        public PCAuthParamList? Bearer { get; set; }

        [JsonProperty("basic")]
        public PCAuthParamList? Basic { get; set; }

        [JsonProperty("digest")]
        public PCAuthParamList? Digest { get; set; }

        [JsonProperty("oauth1")]
        public PCAuthParamList? OAuth1 { get; set; }

        [JsonProperty("oauth2")]
        public PCAuthParamList? OAuth2 { get; set; }

        [JsonProperty("hawk")]
        public PCAuthParamList? Hawk { get; set; }

        [JsonProperty("awsv4")]
        public PCAuthParamList? AWSV4 { get; set; }

        [JsonProperty("ntlm")]
        public PCAuthParamList? NTLM { get; set; }

        [JsonProperty("edgegrid")]
        public PCAuthParamList? EdgeGrid { get; set; }

        [JsonProperty("noauth")]
        public PCNoAuth? NoAuth { get; set; }
    }

    public class PCAuthParamList : PCKeyedListOf<PCAuthParam>
    {
        public PCAuthParamList() : base() { }
        public PCAuthParamList(IEnumerable<PCAuthParam> items) : base(items) { }
    }

    public class PCAuthParam : IPCKeyedValueItem
    {
        [JsonProperty("key")]
        public string Key { get; set; } = "";

        [JsonProperty("value")]
        public string Value { get; set; } = "";

        [JsonProperty("type")]
        public string? Type { get; set; } // "string", etc.
    }

    public class PCNoAuth {  }
}
