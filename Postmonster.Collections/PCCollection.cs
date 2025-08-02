using Newtonsoft.Json;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace Postmonster.Collections
{
    public class PCCollection : IPCItem
    {

        [JsonProperty("info")]
        public PCInfo Info { get; set; } = new();

        [JsonProperty("item")]
        public List<PCItem> Items { get; set; } = new();

        [JsonProperty("event")]
        public List<PCEvent>? Event { get; set; }

        [JsonProperty("variable")]
        public List<PCVariable>? Variable { get; set; }

        [JsonProperty("auth")]
        public PCAuth? Auth { get; set; }

        #region IPCItem Collection Extensions
        [JsonIgnore()]
        public string? Name { get => Info?.Name; set { if (Info != null && value != null) { Info.Name = value; } } }

        [JsonIgnore()]
        public IPCItem? Parent { get => null; set { } }

        [JsonIgnore()]
        public PCItem? Prev { get => null; set { } }

        [JsonIgnore()]
        public PCItem? Next { get => null; set { } }
        public bool HasChildren() => Items?.Count > 0;
        #endregion

        /// <summary>
        /// Parses a Postman collection from a JSON string.
        /// </summary>
        public static PCCollection LoadFromString(string json)
        {
            var result = JsonConvert.DeserializeObject<PCCollection>(json)
                ?? throw new InvalidOperationException("Failed to deserialize Postman collection.");

            // link the collection
            result.Link();

            // return the collection
            return result;
        }

        /// <summary>
        /// Loads a Postman collection from a .json file.
        /// </summary>
        public static PCCollection LoadFromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Collection file not found.", path);

            var json = File.ReadAllText(path);
            return LoadFromString(json);
        }

        public void Link(IPCItem? parent = null)
        {
            PCTree.Link(this, null);
        }

        [JsonIgnore()]
        public bool IsItem { get => false; }

        public PCItem AsItem() => throw new Exception("Not a PCItem");
    }

}
