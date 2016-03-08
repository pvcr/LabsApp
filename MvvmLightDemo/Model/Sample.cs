using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Model
{
    public class Sample:ModelBase
    {
        public string Title { get; set; }

        public SampleDisplayInfo Sample1 { get; set; }

        public SampleDisplayInfo Sample2 { get; set; }

        public SampleDisplayInfo Sample3 { get; set; }

        public SampleDisplayInfo Sample4 { get; set; }

        public SampleDisplayInfo Sample5 { get; set; }

    }

    public class SampleDisplayInfo:ModelBase
    {
        public string MethodName { get; set; }

        public string DueDate { get; set; }

        public int Count { get; set; }
    }


    public class SampleDBInfo : ModelBase
    {
        public string MethodName { get; set; }

        public string DueDate { get; set; }

        public int ID { get; set; }
    }



}
