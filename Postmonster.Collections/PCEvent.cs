using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Collections
{
    public class PCEvent
    {
        [JsonProperty("listen")]
        public string Listen { get; set; } = "test"; // "prerequest" or "test"

        [JsonProperty("script")]
        public PCScript Script { get; set; } = new();
    }

    public class PCScript
    {
        [JsonProperty("type")]
        public string Type { get; set; } = "text/javascript";

        [JsonProperty("exec")]
        public List<string> Exec { get; set; } = new();
    }
}
