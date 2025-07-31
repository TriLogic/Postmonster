using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Postmonster.Runtime
{
    public partial class PRRequest
    {
        public string url { get; set; } = "";
        public string method { get; set; } = "GET";

        [JsonIgnore]
        public PRHeaderList header { get; set; } = new();

        [JsonProperty("header")]
        private object? headerRaw
        {
            get => header.ToList(); // Serialize as array of PRHeader
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

        [JsonIgnore]
        public PRQueryParamList query { get; set; } = new();

        [JsonProperty("query")]
        private object? queryRaw
        {
            get => query.ToList();
            set => query = ParseQueryList(value);
        }

        private static PRQueryParamList ParseQueryList(object? value)
        {
            if (value is JArray array && array.ToObject<List<PRQueryParam>>() is List<PRQueryParam> list)
                return new PRQueryParamList(list);

            return new PRQueryParamList();
        }


        public PRRequestBody? body { get; set; }
    }

}
