using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Collections
{
    public class PCResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; } = "";

        [JsonProperty("originalRequest")]
        public PCRequest? OriginalRequest { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; } = "";

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("header")]
        public List<PCHeader>? Header { get; set; }

        [JsonProperty("body")]
        public string? Body { get; set; }
    }
}
