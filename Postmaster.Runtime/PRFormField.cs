
namespace Postmonster.Runtime
{
    public class PRFormField : IPRKeyedValueItem
    {
        public string key { get; set; } = "";

        public string? value { get; set; } // For "text" type

        public string? src { get; set; } // For "file" type

        public string type { get; set; } = "text"; // "text" or "file"

        public string? description { get; set; }

        public bool? disabled { get; set; }
    }
}
