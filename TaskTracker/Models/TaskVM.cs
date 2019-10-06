using System.Collections.Generic;

namespace TaskTracker.Models
{
    public class TaskVM
    {
        public int TaskId { get; set; }
        public int ManagerId{ get; set; }
        public bool IsCompleted { get; set; }
        public virtual List<StatusVM> StatusReports { get; set; }

    }
}