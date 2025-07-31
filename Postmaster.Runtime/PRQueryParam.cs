using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Runtime
{
    public class PRQueryParam : IPRKeyedValue
    {
        public string key { get; set; } = "";
        public string value { get; set; } = "";
        public string? description { get; set; }
        public bool? disabled { get; set; }
    }
}
