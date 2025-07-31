using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Collections
{
    public class PCRequest
    {
        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;

        [JsonProperty("method")]
        public string Method { get; set; } = "GET";

        [JsonProperty("header")]
        public PCHeaderList? Header { get; set; }

        [JsonProperty("body")]
        public PCRequestBody? Body { get; set; }
    }
}
