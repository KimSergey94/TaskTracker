using System.Collections.Generic;

namespace BLL_TaskTracker.DTO
{
    public class TaskDTO
    {
        public int TaskId { get; set; }

        public bool IsCompleted { get; set; }
        public string TaskDefinition { get; set; }

        public int NumberOfSteps { get; set; }


        public int ManagerId { get; set; }
        public virtual ManagerDTO Manager { get; set; }

        public int EmployeeId { get; set; }
        public virtual EmployeeDTO Employee { get; set; }


        public virtual ICollection<StatusDTO> Statuses { get; set; }




    }
}