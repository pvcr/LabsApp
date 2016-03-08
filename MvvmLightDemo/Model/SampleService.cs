using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Model
{
    public class SampleService : ISampleService
    {
        public void GetModel(Action<Sample, Exception> callback)
        {
            var groups = from sample in GetSampleDBInfos()
                         group sample by sample.MethodName
            into g
                         select new SampleDisplayInfo
                         {
                             MethodName = g.Key,
                             Count = g.Count(),
                             DueDate=DateTime.Now.ToLongDateString()
                         };


            

            var item = new Sample()
            {
                Title = "Sample",
                Sample1 = groups.ElementAt(0),
                Sample2 = groups.ElementAt(1),
                Sample3 = groups.ElementAt(2),
                Sample4 = groups.ElementAt(3),
                Sample5 = groups.ElementAt(4)


            };
            callback(item, null);
        }

        private SampleDisplayInfo GetSampleInfo(int index)
        {
            return new SampleDisplayInfo()
            {
                MethodName = string.Format("Group {0}", index),
                DueDate = DateTime.Now.ToLongDateString(),
                Count = 3
            };
        }

        private List<SampleDBInfo> GetSampleDBInfos()
        {

            return new List<SampleDBInfo>() {

                new SampleDBInfo { MethodName="Group1", DueDate=DateTime.Now.ToLongDateString(), ID=1001 },
                new SampleDBInfo { MethodName="Group1", DueDate=DateTime.Now.ToLongDateString(), ID=1002 },
                new SampleDBInfo { MethodName="Group1", DueDate=DateTime.Now.ToLongDateString(), ID=1003 },
                new SampleDBInfo { MethodName="Group1", DueDate=DateTime.Now.ToLongDateString(), ID=1004 },

                new SampleDBInfo { MethodName="Group100", DueDate=DateTime.Now.ToLongDateString(), ID=1005 },
                new SampleDBInfo { MethodName="Group100", DueDate=DateTime.Now.ToLongDateString(), ID=1006 },
                new SampleDBInfo { MethodName="Group100", DueDate=DateTime.Now.ToLongDateString(), ID=1007 },
                new SampleDBInfo { MethodName="Group100", DueDate=DateTime.Now.ToLongDateString(), ID=1008 },

                new SampleDBInfo { MethodName="Group111", DueDate=DateTime.Now.ToLongDateString(), ID=1009 },
                new SampleDBInfo { MethodName="Group111", DueDate=DateTime.Now.ToLongDateString(), ID=10010 },
                new SampleDBInfo { MethodName="Group111", DueDate=DateTime.Now.ToLongDateString(), ID=10011 },
                new SampleDBInfo { MethodName="Group111", DueDate=DateTime.Now.ToLongDateString(), ID=10012 },

                new SampleDBInfo { MethodName="Group133", DueDate=DateTime.Now.ToLongDateString(), ID=10013 },
                new SampleDBInfo { MethodName="Group133", DueDate=DateTime.Now.ToLongDateString(), ID=10014 },
                new SampleDBInfo { MethodName="Group133", DueDate=DateTime.Now.ToLongDateString(), ID=10015 },
                new SampleDBInfo { MethodName="Group133", DueDate=DateTime.Now.ToLongDateString(), ID=10016 },

                new SampleDBInfo { MethodName="Group133", DueDate=DateTime.Now.ToLongDateString(), ID=10017 },
                new SampleDBInfo { MethodName="Group133", DueDate=DateTime.Now.ToLongDateString(), ID=10018 },
                new SampleDBInfo { MethodName="Group133", DueDate=DateTime.Now.ToLongDateString(), ID=10019 },
                new SampleDBInfo { MethodName="Group133", DueDate=DateTime.Now.ToLongDateString(), ID=1002 },

                new SampleDBInfo { MethodName="Group21", DueDate=DateTime.Now.ToLongDateString(), ID=10021 },
                new SampleDBInfo { MethodName="Group21", DueDate=DateTime.Now.ToLongDateString(), ID=10022 },
                new SampleDBInfo { MethodName="Group21", DueDate=DateTime.Now.ToLongDateString(), ID=10023 },
                new SampleDBInfo { MethodName="Group21", DueDate=DateTime.Now.ToLongDateString(), ID=10024 },

                new SampleDBInfo { MethodName="Group21", DueDate=DateTime.Now.ToLongDateString(), ID=10025 },
                new SampleDBInfo { MethodName="Group21", DueDate=DateTime.Now.ToLongDateString(), ID=10026 },
                new SampleDBInfo { MethodName="Group21", DueDate=DateTime.Now.ToLongDateString(), ID=10027 },
                new SampleDBInfo { MethodName="Group1", DueDate=DateTime.Now.ToLongDateString(), ID=1001 },

                 new SampleDBInfo { MethodName="Group1", DueDate=DateTime.Now.ToLongDateString(), ID=1001 },
                new SampleDBInfo { MethodName="Group1", DueDate=DateTime.Now.ToLongDateString(), ID=1001 },
                new SampleDBInfo { MethodName="Group1", DueDate=DateTime.Now.ToLongDateString(), ID=1001 },
                new SampleDBInfo { MethodName="Group1", DueDate=DateTime.Now.ToLongDateString(), ID=1001 },


            };
        }


     
    }
}
