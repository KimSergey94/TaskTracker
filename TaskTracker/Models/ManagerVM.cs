using System.Collections.Generic;


namespace TaskTracker.Models
{
    public class ManagerVM 
    {
        public int ManagerId { get; set; }
        public int EmployeeId { get; set; }
        public virtual List<TaskVM> Tasks { get; set; }

    }
}