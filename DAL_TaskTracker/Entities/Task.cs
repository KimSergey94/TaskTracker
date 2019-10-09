using System.Collections.Generic;

namespace DAL_TaskTracker.Entities
{
    public class Task
    {
        public int TaskId { get; set; }

        public bool IsCompleted { get; set; }
        public string TaskDefinition { get; set; }

        public int NumberOfSteps { get; set; }


        public int ManagerId { get; set; }
        public int EmployeeId { get; set; }
        public int ClientId { get; set; }


        public virtual ICollection<Status> Statuses { get; set; }
    }
}