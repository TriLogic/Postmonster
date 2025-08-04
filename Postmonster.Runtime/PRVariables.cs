using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Postmonster.Runtime
{
    public partial class PRVariables
    {
        private readonly Dictionary<string, string> _vars = new();

        [JsonIgnore]
        public IReadOnlyDictionary<string, string> All => _vars;

        public bool has(string key) => 
            _vars.ContainsKey(key);

        public string? get(string key) => 
            _vars.TryGetValue(key, out var val) ? val : null;

        public void set(string key, string value)
        {
            if (_vars.ContainsKey(key)) 
                _vars.Remove(key);
            _vars[key] = value;
        }

        public void unset(string key) =>
            _vars.Remove(key);

        public void clear() => 
            _vars.Clear();

        [JsonExtensionData]
        public Dictionary<string, JToken> DynamicData
        {
            get => _vars.ToDictionary(kv => kv.Key, kv => (JToken)kv.Value);
            set => _vars.Clear(); // Optional: or rebuild _vars from JToken if needed
        }

        // FIXME: needs the following methods
        //  * toObject()    - return a Json object
        //  * keys()        -  return an array of keys
    }
}
