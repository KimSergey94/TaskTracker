using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TaskTracker.Entities
{
    public class Email
    {
        public int EmailId { get; set; }
        public int ClientId { get; set; }
        public int TaskId { get; set; }
        public int ManagerId { get; set; }
    }
}
