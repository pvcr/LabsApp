using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Model
{
    public class TestingService : ITestingService
    {
        public void GetModel(Action<Testing, Exception> callback)
        {
            var item = new Testing() { Title = "Testing" };
            callback(item, null);
        }
    }
}
