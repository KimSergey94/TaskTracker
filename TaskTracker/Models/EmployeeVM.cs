﻿

namespace TaskTracker.Models
{
    public class EmployeeVM
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public int UserId { get; set; }
    }
}