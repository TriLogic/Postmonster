using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Collections
{
    public class PCItem
    {
        [JsonProperty("name")]
        public string Name { get; set; } = "";

        [JsonProperty("item")]
        public List<PCItem>? SubItems { get; set; } // If it's a folder

        [JsonProperty("request")]
        public PCRequest? Request { get; set; } // If it's a request

        [JsonProperty("response")]
        public List<PCResponse>? Response { get; set; }

        [JsonProperty("event")]
        public List<PCEvent>? Event { get; set; }
    }
}
