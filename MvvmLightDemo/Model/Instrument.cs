using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Model
{
    public class Instrument:ModelBase
    {
        public string Title { get; set; }

        public InstrumentDisplayInfo Instrument1 { get; set; }

        public InstrumentDisplayInfo Instrument2 { get; set; }

        public InstrumentDisplayInfo Instrument3 { get; set; }

        public InstrumentDisplayInfo Instrument4 { get; set; }

    }


    public class InstrumentDisplayInfo : ModelBase
    {
        public string MethodName { get; set; }

        public string DueDate { get; set; }

        public int Count { get; set; }

        public string FlaskPath { get; set; }

        public string InstrmentPath { get; set; }

     
    }


    public class InstrumentDBInfo : ModelBase
    {
        public string MethodName { get; set; }

        public string DueDate { get; set; }

        public int ID { get; set; }
    }




}
