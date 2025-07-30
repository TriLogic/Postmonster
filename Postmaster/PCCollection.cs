using Newtonsoft.Json;

namespace Postmonster.Collections
{
    public class PCCollection
    {
        [JsonProperty("info")]
        public PCInfo Info { get; set; } = new();

        [JsonProperty("item")]
        public List<PCItem> Item { get; set; } = new();

        [JsonProperty("event")]
        public List<PCEvent>? Event { get; set; }

        [JsonProperty("variable")]
        public List<PCVariable>? Variable { get; set; }

        [JsonProperty("auth")]
        public PCAuth? Auth { get; set; }


        /// <summary>
        /// Parses a Postman collection from a JSON string.
        /// </summary>
        public static PCCollection FromString(string json)
        {
            return JsonConvert.DeserializeObject<PCCollection>(json)
                ?? throw new InvalidOperationException("Failed to deserialize Postman collection.");
        }

        /// <summary>
        /// Loads a Postman collection from a .json file.
        /// </summary>
        public static PCCollection FromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Collection file not found.", path);

            var json = File.ReadAllText(path);
            return FromString(json);
        }
    }

}
