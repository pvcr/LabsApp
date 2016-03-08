using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Model
{
    public class ExceptionService : IExceptionService
    {
        public void GetModel(Action<Exceptions, Exception> callback)
        {
            var item = new Exceptions() { Title = "Exceptions " };
            callback(item, null);
        }
    }
}
