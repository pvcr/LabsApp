using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Model
{
    public class ScheduleService : IScheduleService
    {
        public void GetModel(Action<Schedule, Exception> callback)
        {
            var item = new Schedule() { Title= "Schedule" };
            callback(item, null);
        }
    }
}
