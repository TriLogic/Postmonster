using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;

namespace Postmonster.Runtime
{
    public interface IPRVariables
    {
        public bool has(string key);

        public string? get(string key);

        public void set(string key, string value);

        public void unset(string key);

        public void clear();
    }

    public partial class PRVariables : IPRVariables
    {
        private readonly Dictionary<string, string?> _vars = new();

        public PRVariables()
        {
        }

        public PRVariables(Dictionary<string, string?> vars)
        {
            _vars = new();
        }

        [JsonIgnore]
        public IReadOnlyDictionary<string, string?> All => _vars;

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

    public partial class PRReadOnlyWrapper : IPRVariables
    {
        private IPRVariables _vars;

        public PRReadOnlyWrapper(IPRVariables vars)
        {
            _vars = vars;
        }

        public bool has(string key) =>
            _vars.has(key);

        public string? get(string key) =>
            _vars.get(key);

        public void set(string key, string value) =>
            throw new Exception("read only variables");

        public void unset(string key) => 
            throw new Exception("read only variables");

        public void clear() => 
            throw new Exception("read only variables");
    }

    public class PRPmVariableScope : IPRVariables
    {
        private readonly Func<string, bool> hasser;
        private readonly Func<string, string?> getter;
        private readonly Action<string, string?> setter;
        private readonly Action<string> unsetter;
        private readonly Action clearer;

        public PRPmVariableScope(
            Func<string, bool> hasser,
            Func<string, string?> getter,
            Action<string, string?> setter,
            Action<string> unsetter,
            Action clearer)
        {
            this.hasser = hasser;
            this.getter = getter;
            this.setter = setter;
            this.unsetter = unsetter;
            this.clearer = clearer;
        }

        // Optional: expose methods if IPRVariables requires them
        public bool has(string key) => hasser(key);
        public string? get(string key) => getter(key);
        public void set(string key, string? value) => setter(key, value);
        public void unset(string key) => unsetter(key);
        public void clear() => clearer();
    }

}
