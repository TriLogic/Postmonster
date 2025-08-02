using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Postmonster.Collections
{
    public interface IPCItem
    {
        public string Name { get; set; }
        public IPCItem? Parent { get; set; }
        public PCItem? Prev { get; set; }
        public PCItem? Next { get; set; }
        public List<PCItem>? Items { get; set; }
        public bool HasChildren();
        public void Link(IPCItem? parent);
        public bool IsItem { get; }
        public PCItem AsItem();
    }

    public class PCItem : IPCItem
    {
        [JsonProperty("name")]
        public string Name { get; set; } = "";

        [JsonProperty("item")]
        public List<PCItem>? Items { get; set; } // If it's a folder

        [JsonProperty("request")]
        public PCRequest? Request { get; set; } // If it's a request

        [JsonProperty("response")]
        public List<PCResponse>? Response { get; set; }

        [JsonProperty("event")]
        public List<PCEvent>? Event { get; set; }

        #region IPCItem Collection Extensions
        [JsonIgnore()]
        public IPCItem? Parent { get; set; }

        [JsonIgnore()]
        public PCItem? Prev { get; set; }

        [JsonIgnore()]
        public PCItem? Next { get; set; }

        public bool HasChildren() => Items?.Count > 0;

        public void Link(IPCItem? parent)
        {
            PCTree.Link(this, parent);
        }

        [JsonIgnore()]
        public bool IsItem { get => true; }
        public PCItem AsItem() => this;

        #endregion
    }
}

