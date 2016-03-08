using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Model
{
    public class NavService : INavService
    {
        public void GetModel(Action<Nav, Exception> callback)
        {
            var item = new Nav() { Title = "Nav " };
            callback(item, null);
        }
    }
}
