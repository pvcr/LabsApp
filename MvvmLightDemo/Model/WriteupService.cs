using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Model
{
    public class WriteupService : IWriteupService
    {
        public void GetModel(Action<Writeup, Exception> callback)
        {
            var item = new Writeup() { Title= "Write up" };
            callback(item, null);
        }
    }
}
