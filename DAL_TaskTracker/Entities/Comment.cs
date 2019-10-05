using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_TaskTracker.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int StatusId { get; set; }
        public string Message { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
