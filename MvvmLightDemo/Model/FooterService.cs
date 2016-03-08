using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Model
{
    public class FooterService : IFooterService
    {
       
        public void GetModel(Action<Footer, Exception> callback)
        {
            var item = new Footer("Copyright © 2016.All rights reserved.", "1.0", "Status");
            callback(item, null);
        }
    }
}
