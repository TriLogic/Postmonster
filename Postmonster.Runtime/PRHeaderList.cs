using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Runtime
{
    public class PRHeaderList : PRKeyedListOf<PRHeader>
    {
        public PRHeaderList() : base() { }
        public PRHeaderList(IEnumerable<PRHeader> items) : base(items) { }
    }
}
