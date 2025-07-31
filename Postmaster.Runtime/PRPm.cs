using Postmonster.Asserts;

namespace Postmonster.Runtime
{
    public partial class PRPm
    {
        public PRRequest request { get; set; } = new();

        public PRResponse response { get; set; } = new();

        public PRVariables environment { get; set; } = new();

        public PRVariables globals { get; set; } = new();

        public PRVariables variables { get; set; } = new();

        public PRVariables collectionVariables { get; set; } = new();

        public Dictionary<string, string> iterationData { get; set; } = new();

        public PRExecutionInfo info { get; set; } = new();

        public PAExpect expect { get; set; } = new();
    }
}
