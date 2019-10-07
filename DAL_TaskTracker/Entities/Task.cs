using System.Collections.Generic;

namespace DAL_TaskTracker.Entities
{
    public class Task
    {
        public int TaskId { get; set; }
        public int ManagerId{ get; set; }
        public bool IsCompleted { get; set; }
        public string TaskDefinition { get; set; }
        public virtual List<Status> StatusReports { get; set; }

    }
}