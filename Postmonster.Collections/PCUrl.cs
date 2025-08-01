using Newtonsoft.Json;

namespace Postmonster.Collections
{
    public class PCUrl
    {
        [JsonProperty("raw")]
        public string Raw { get; set; } = "";

        [JsonProperty("protocol")]
        public string? Protocol { get; set; }

        [JsonProperty("host")]
        public List<string>? Host { get; set; }

        [JsonProperty("path")]
        public List<string>? Path { get; set; }

        [JsonProperty("query")]
        public List<PCQueryParam>? Query { get; set; }

        [JsonProperty("variable")]
        public List<PCUrlVariable>? Variable { get; set; }
    }

    public class PCQueryParam : IPCKeyedValueItem
    {
        [JsonProperty("key")]
        public string Key { get; set; } = "";

        [JsonProperty("value")]
        public string Value { get; set; } = "";

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("disabled")]
        public bool? Disabled { get; set; }
    }

    public class PCUrlVariable : IPCKeyedValueItem
    {
        [JsonProperty("key")]
        public string Key { get; set; } = "";

        [JsonProperty("value")]
        public string Value { get; set; } = "";
    }

    public class PCUrlConverter : JsonConverter<PCUrl>
    {
        public override PCUrl ReadJson(JsonReader reader, Type objectType, PCUrl existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                // Simple string URL
                return new PCUrl { Raw = reader.Value?.ToString() ?? string.Empty };
            }
            else if (reader.TokenType == JsonToken.StartObject)
            {
                // Structured PCUrl
                return serializer.Deserialize<PCUrl>(reader) ?? new PCUrl();
            }

            return new PCUrl();
        }

        public override void WriteJson(JsonWriter writer, PCUrl value, JsonSerializer serializer)
        {
            if (value.Protocol == null && value.Host == null && value.Path == null)
            {
                // Serialize as simple string if only Raw is set
                writer.WriteValue(value.Raw);
            }
            else
            {
                serializer.Serialize(writer, value);
            }
        }
    }

}
