using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Collections
{
    public class PCHeaderItem : IPCKeyedValueItem
    {
        [JsonProperty("key")]
        public string Key { get; set; } = "";

        [JsonProperty("value")]
        public string? Value { get; set; } = "";

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("disabled")]
        public bool? Disabled { get; set; }
    }
}
