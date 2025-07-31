using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Collections
{
    public class PCHeaderList : PCKeyedListOf<PCHeaderItem>
    {
        public PCHeaderList() : base() { }
        public PCHeaderList(IEnumerable<PCHeaderItem> items) : base(items) { }
    }
}
