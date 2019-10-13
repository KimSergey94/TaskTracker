using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTracker.Models
{
    public class ClientTaskVM
    {
        public int TaskId { get; set; }
        public string TaskDefinition { get; set; }
        public string ManagerName { get; set; }
        public string ManagerEmail { get; set; }
    }
}