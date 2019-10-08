using System.Collections.Generic;

namespace DAL_TaskTracker.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }

        public int StatusId { get; set; }
        //public virtual Status Status { get; set; }

        public string Message { get; set; }
    }
}
