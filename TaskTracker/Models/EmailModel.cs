using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTracker.Models
{
    public class EmailModel
    {
        public int EmailId { get; set; }
        public int ClientId { get; set; }
        public int TaskId { get; set; }
        public int ManagerId { get; set; }

    }
}