using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTracker.Models
{
    public class ManagerViewModel : EmployeeViewModel
    {
        public int ManagerId { get; set; }
        public int EmployeeId { get; set; }
        public virtual EmployeeViewModel Employee { get; set; }
        public virtual List<TaskViewModel> Tasks { get; set; }

    }
}