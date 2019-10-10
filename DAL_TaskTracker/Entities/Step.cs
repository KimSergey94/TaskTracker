using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_TaskTracker.Entities
{
    public class Step
    {
        public int StepId { get; set; }
        public int TaskId { get; set; }
        public string Message { get; set; }
        public bool IsCompleted { get; set; }
        //public virtual ICollection<Comment> Comments { get; set; }
    }
}