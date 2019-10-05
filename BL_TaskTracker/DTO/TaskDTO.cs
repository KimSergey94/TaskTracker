using System.Collections.Generic;

namespace BLL_TaskTracker.DTO
{
    public class TaskDTO
    {
        public int TaskId { get; set; }
        public int ManagerId{ get; set; }
        public bool IsCompleted { get; set; }

    }
}