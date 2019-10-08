using System.Collections.Generic;

namespace DAL_TaskTracker.Entities
{
    public class Status
    {
        public int StatusId { get; set; }

        public int TaskId { get; set; }
        //public virtual Task Task { get; set; }

        public string Message { get; set; }
        public bool IsCompleted { get; set; }

        //public virtual ICollection<Comment> Comments { get; set; }
    }
}