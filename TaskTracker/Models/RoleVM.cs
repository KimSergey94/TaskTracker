using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTracker.Models
{
    public class RoleVM
    {
        public int RoleId { get; set; }
        //public int UserId { get; set; }
        //public virtual UserDTO UserDTO { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserVM> Users { get; set; }
    }
}