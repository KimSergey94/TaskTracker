using System.Collections.Generic;

namespace DAL_TaskTracker.Entities
{
    public class Status
    {
        public int StatusId { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}