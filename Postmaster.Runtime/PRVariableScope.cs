using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Postmonster.Runtime
{
    public class PRVariableScope
    {
        private readonly Dictionary<string, string> _vars = new();

        [JsonIgnore]
        public IReadOnlyDictionary<string, string> All => _vars;

        public bool Has(string key) => _vars.ContainsKey(key);

        public string? Get(string key) =>
            _vars.TryGetValue(key, out var val) ? val : null;

        public void Set(string key, string value) =>
            _vars[key] = value;

        public void Unset(string key) =>
            _vars.Remove(key);

        public void Clear() => _vars.Clear();

        [JsonExtensionData]
        public Dictionary<string, JToken> DynamicData
        {
            get => _vars.ToDictionary(kv => kv.Key, kv => (JToken)kv.Value);
            set => _vars.Clear(); // Optional: or rebuild _vars from JToken if needed
        }
    }
}
