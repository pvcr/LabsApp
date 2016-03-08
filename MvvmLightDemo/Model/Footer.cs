using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Model
{
    public class Footer:ModelBase
    {
        public string CopyRights
        {
            get;
            private set;
        }

        public string Version
        {
            get;
            private set;
        }

        public string StatusMessage
        {
            get;
            set;
        }

        public string CurrentDateTime
        {
            get;
            private set;
        }

        public Footer(string copyrights,string ver,string statusmsg)
        {
            CopyRights = copyrights;
            Version = ver;
            StatusMessage = statusmsg;
            CurrentDateTime = DateTime.Now.ToLongDateString();
        }
       
    }
}
