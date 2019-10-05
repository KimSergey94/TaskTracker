﻿using System.Collections.Generic;


namespace DAL_TaskTracker.Entities
{
    public class Manager : Employee
    {
        public int ManagerId { get; set; }
        public int EmployeeId { get; set; }
        public virtual List<Task> Tasks { get; set; }

    }
}