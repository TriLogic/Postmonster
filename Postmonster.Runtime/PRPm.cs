using Postmonster.Asserts;

namespace Postmonster.Runtime
{
    public partial class PRPm
    {
        public PRPm()
        {
            setVariableScoping();
        }

        public PRPm(Dictionary<string, string?>? data)
        {
            iterationData = data == null ? null : new PRReadOnlyWrapper(new PRVariables(data));
        }

        public PRPm(PRVariables data)
        {
            iterationData = data == null ? null : new PRReadOnlyWrapper(data);
        }

        private void setVariableScoping()
        {
            variables = new PRPmVariableScope(
                hasser: key => this.getVariablesFor(key) != null,
                getter: key => {
                    var owner = getVariablesFor(key);
                    return owner != null ? owner.get(key) : locals.get(key);
                },
                setter: (key, value) => {
                    locals.set(key, value);
                },
                unsetter: key => {
                    locals.unset(key);
                },
                clearer: () => {
                    locals.clear();
                }
            );
        }

        public PRRequest request { get; set; } = new();
        public PRResponse response { get; set; } = new();
        public PRPmVariableScope variables { get; set; }
        public PRVariables locals { get; set; } = new();
        public PRVariables environment { get; set; } = new();
        public PRVariables collectionVariables { get; set; } = new();
        public PRVariables globals { get; set; } = new();
        public PRReadOnlyWrapper? iterationData { get; internal set;}
        public PRExecutionInfo info { get; set; } = new();
        public PAExpect expect { get; set; } = new();

        private IPRVariables? getVariablesFor(string key)
        {
            IPRVariables? result;
            
            result = locals.has(key) ? locals : null;
            result = result == null && iterationData != null && iterationData.has(key) ? iterationData : null;
            result = result == null && environment.has(key) ? environment : null;
            result = result == null && collectionVariables.has(key) ? collectionVariables : null;
            result = result == null && globals.has(key) ? globals: null;

            return result;
        }
    }
}
