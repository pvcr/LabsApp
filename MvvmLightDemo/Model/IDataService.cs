using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labs.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);

        void GetModel(Action<ModelBase, Exception> callback);
    }
}
