﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Model
{
    public interface ICommentService
    {

        void GetModel(Action<Comment, Exception> callback);
    }
}
