using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models
{
    public class CommentVM
    {
        [Key]

        public int CommentId { get; set; }

        public int StatusId { get; set; }
        public virtual StatusVM Status { get; set; }

        public string Message { get; set; }
    }
}
