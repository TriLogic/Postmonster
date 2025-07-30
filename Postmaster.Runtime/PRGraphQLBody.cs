using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Runtime
{
    public class PRGraphQLBody
    {
        public string query { get; set; } = "";

        public string variables { get; set; } = "{}"; // JSON string
    }
}
