using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Postmonster.Runtime
{

    public class PRResponse
    {
        public string status { get; set; } = "";       // e.g., "OK"
        public int code { get; set; } = 0;             // e.g., 200
        public int? responseTime { get; set; }         // optional, in ms
        public string? body { get; set; }              // raw body string

        [JsonIgnore]
        public PRHeaderList header { get; set; } = new();

        [JsonProperty("header")]
        private object? headerRaw
        {
            get => header.ToList(); // Always serialize as array
            set
            {
                switch (value)
                {
                    case JArray array:
                        var list = array.ToObject<List<PRHeader>>();
                        if (list != null) header = new PRHeaderList(list);
                        break;

                    case JObject obj:
                        header = new PRHeaderList(
                            obj.Properties().Select(p => new PRHeader
                            {
                                key = p.Name,
                                value = p.Value?.ToString() ?? ""
                            })
                        );
                        break;

                    case IDictionary<string, object> dict:
                        header = new PRHeaderList(
                            dict.Select(kv => new PRHeader
                            {
                                key = kv.Key,
                                value = kv.Value?.ToString() ?? ""
                            })
                        );
                        break;

                    case null:
                        header = new PRHeaderList();
                        break;
                }
            }
        }
    }

}
