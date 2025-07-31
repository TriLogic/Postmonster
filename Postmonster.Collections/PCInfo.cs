using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Collections
{
    public class PCInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; } = "Postmonster Collection";

        [JsonProperty("_postman_id")]
        public string PostmanId { get; set; } = Guid.NewGuid().ToString();

        [JsonProperty("schema")]
        public string Schema { get; set; } = "https://schema.getpostman.com/json/collection/v2.1.0/collection.json";
    }
}
