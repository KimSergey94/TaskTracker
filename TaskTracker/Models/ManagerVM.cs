using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models
{
    public class ManagerVM 
    {
        [Key]
        public int ManagerId { get; set; }
        public int EmployeeId { get; set; }

        //public virtual ICollection<TaskVM> Tasks { get; set; }


    }
}