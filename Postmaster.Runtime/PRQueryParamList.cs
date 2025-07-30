using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Runtime
{
    public class PRQueryParamList : PRKeyedList<PRQueryParam>
    {
        public PRQueryParamList() : base() { }
        public PRQueryParamList(IEnumerable<PRQueryParam> items) : base(items) { }
        protected override string GetKey(PRQueryParam item) => item.key;
        protected override void SetKey(PRQueryParam item, string key) => item.key = key;
    }
}
