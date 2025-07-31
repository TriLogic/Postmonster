using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Runtime
{
    public class PRCookieList : PRNamedListOf<PRCookie>
    {
        public PRCookieList() : base() { }
        public PRCookieList(IEnumerable<PRCookie> items) : base(items) { }
    }
}
