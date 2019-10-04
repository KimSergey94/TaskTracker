using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTracker.Models
{
    public class Manager : Employee
    {
        public int ManagerId { get; set; }
        public Employee employee { get; set; }
    }
}