using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Runtime
{
    public class PRCookieList : PRKeyedList<PRCookie>
    {
        protected override string GetKey(PRCookie item) => item.name;
        protected override void SetKey(PRCookie item, string key) => item.name = key;
    }
}
