using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTracker.Models
{
    public class TaskViewModel
    {
        public int TaskId { get; set; }
        public int ManagerId{ get; set; }
        public bool IsCompleted { get; set; }
        public virtual List<StatusViewModel> StatusReports { get; set; }

    }
}