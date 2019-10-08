using System.Collections.Generic;


namespace TaskTracker.Models
{
    public class ManagerVM 
    {
        public int ManagerId { get; set; }
        public int EmployeeId { get; set; }
        public virtual EmployeeVM Employee { get; set; }

        public virtual ICollection<TaskVM> Tasks { get; set; }

        //public int UserId { get; set; }
        //public virtual UserDTO User { get; set; }

    }
}