using System.Collections.Generic;

namespace TaskTracker.Models
{
    public class TaskVM
    {
        public int TaskId { get; set; }

        public bool IsCompleted { get; set; }
        public string TaskDefinition { get; set; }

        public int NumberOfSteps { get; set; }


        public int ManagerId { get; set; }
        public virtual ManagerVM Manager { get; set; }

        public int EmployeeId { get; set; }
        public virtual EmployeeVM Employee { get; set; }


        public virtual ICollection<StatusVM> Statuses { get; set; }
    
    }
}