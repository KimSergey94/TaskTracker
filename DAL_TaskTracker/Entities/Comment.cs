using System.Collections.Generic;

namespace DAL_TaskTracker.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int StatusId { get; set; }
        public string Message { get; set; }

        public virtual List<Status> StatusReports { get; set; }
    }
}
