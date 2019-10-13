using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_TaskTracker.DTO
{
    public class EmailDTO
    {
        public int EmailId { get; set; }
        public int ClientId { get; set; }
        public int TaskId { get; set; }
        public int ManagerId { get; set; }
    }
}
