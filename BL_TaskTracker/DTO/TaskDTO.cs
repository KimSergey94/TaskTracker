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
        public int EmployeeId { get; set; }
        public int ClientId { get; set; }


        public virtual ICollection<StepDTO> Steps { get; set; }
        public virtual ICollection<EmployeeDTO> Employees { get; set; }   //
    }
}