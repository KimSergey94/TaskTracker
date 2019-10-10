using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_TaskTracker.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int StepId { get; set; }
        public string Message { get; set; }
    }
}
