using System.Collections.Generic;

namespace TaskTracker.Models
{
    public class CommentVM
    {
        public int CommentId { get; set; }

        public int StatusId { get; set; }
        public virtual StatusVM Status { get; set; }

        public string Message { get; set; }
    }
}
