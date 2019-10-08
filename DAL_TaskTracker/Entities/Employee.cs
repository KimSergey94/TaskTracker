

using System.Collections.Generic;

namespace DAL_TaskTracker.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }


        //[Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }


        //[Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        //[Required(ErrorMessage = "Country field is required")]
        public string Country { get; set; }

        public string Position { get; set; }
        public int Salary { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}