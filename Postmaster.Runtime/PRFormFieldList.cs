using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Runtime
{
    public class PRFormFieldList : PRKeyedList<PRFormField>
    {
        public PRFormFieldList() : base() { }
        public PRFormFieldList(IEnumerable<PRFormField> items) : base(items) { }
        protected override string GetKey(PRFormField item) => item.key;
        protected override void SetKey(PRFormField item, string key) => item.key = key;
    }
}
