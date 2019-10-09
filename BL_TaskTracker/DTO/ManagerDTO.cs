using System.Collections.Generic;

namespace BLL_TaskTracker.DTO
{
    public class ManagerDTO 
    {
        public int ManagerId { get; set; }
        public int EmployeeId { get; set; }
        
        public virtual ICollection<TaskDTO> Tasks { get; set; }

        //public int UserId { get; set; }
        //public virtual UserDTO User { get; set; }
    }
}