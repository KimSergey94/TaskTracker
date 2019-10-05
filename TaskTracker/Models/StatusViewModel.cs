using BL_TaskTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTracker.Models
{
    public class StatusViewModel
    {
        public int StatusId { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}