

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_TaskTracker.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public int UserId { get; set; }
        //public virtual ICollection<Task> Tasks { get; set; }

    }
}