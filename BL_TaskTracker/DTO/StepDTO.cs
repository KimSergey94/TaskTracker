using System.Collections.Generic;

namespace BLL_TaskTracker.DTO
{
    public class StepDTO
    {
        public int StepId { get; set; }

        public int TaskId { get; set; }

        public string Message { get; set; }
        public bool IsCompleted { get; set; }

        public virtual ICollection<CommentDTO> Comments { get; set; }

    }
}