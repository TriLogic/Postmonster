using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Runtime
{
    public class PRQueryParamList : PRKeyedListOf<PRQueryParam>
    {
        public PRQueryParamList() : base() { }
        public PRQueryParamList(IEnumerable<PRQueryParam> items) : base(items) { }
    }
}
