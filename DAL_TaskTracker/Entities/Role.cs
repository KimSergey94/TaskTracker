﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TaskTracker.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        //public virtual ICollection<User> Users { get; set; }

    }
}
