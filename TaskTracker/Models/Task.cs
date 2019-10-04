using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTracker.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public bool[] Steps { get; set; }
        public string[] Comments { get; set; }
    }
}