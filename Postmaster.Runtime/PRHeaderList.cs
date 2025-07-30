using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Runtime
{
    public class PRHeaderList : PRKeyedList<PRHeader>
    {
        public PRHeaderList() : base() { }

        public PRHeaderList(IEnumerable<PRHeader> items) : base(items) { }

        protected override string GetKey(PRHeader item) => item.key;
        protected override void SetKey(PRHeader item, string key) => item.key = key;
    }
}
