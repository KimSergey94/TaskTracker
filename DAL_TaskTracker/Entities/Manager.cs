﻿using System.Collections.Generic;


namespace DAL_TaskTracker.Entities
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public int EmployeeId { get; set; }
        //public virtual Employee Employee { get; set; }

        //public virtual ICollection<Task> Tasks { get; set; }

        //public int UserId { get; set; }
        //public virtual UserDTO User { get; set; }
    }
}