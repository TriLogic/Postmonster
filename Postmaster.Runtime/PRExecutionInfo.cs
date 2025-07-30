using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Runtime
{
    public class PRExecutionInfo
    {
        public int iteration { get; set; }

        public string? requestName { get; set; }

        public string? collectionName { get; set; }

        public string? folderName { get; set; }
    }
}
