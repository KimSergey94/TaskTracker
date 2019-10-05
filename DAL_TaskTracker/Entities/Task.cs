using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTracker.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public int ManagerId{ get; set; }
        public bool IsCompleted { get; set; }
        public virtual List<Status> StatusReports { get; set; }

    }
}