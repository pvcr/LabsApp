using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Model
{
    public class CommentService : ICommentService
    {
        public void GetModel(Action<Comment, Exception> callback)
        {
            var item = new Comment() { Title= "Comment" };
            callback(item, null);
        }
    }
}
