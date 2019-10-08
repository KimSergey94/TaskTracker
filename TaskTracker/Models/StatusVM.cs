
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models
{
    public class StatusVM
    {
        [Key]
        public int StatusId { get; set; }

        public int TaskId { get; set; }
        public virtual TaskVM Task { get; set; }

        public string Message { get; set; }
        public bool IsCompleted { get; set; }

        public virtual ICollection<CommentVM> Comments { get; set; }
    }
}