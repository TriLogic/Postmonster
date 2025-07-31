using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Runtime
{
    public class PRFormFieldList : PRKeyedListOf<PRFormField>
    {
        public PRFormFieldList() : base() { }
        public PRFormFieldList(IEnumerable<PRFormField> items) : base(items) { }
    }
}
