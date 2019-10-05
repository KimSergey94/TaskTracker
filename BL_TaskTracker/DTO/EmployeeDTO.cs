
using System.ComponentModel.DataAnnotations;

namespace BLL_TaskTracker.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }


        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Country field is required")]
        public string Country { get; set; }

        public string Position { get; set; }
        public int Salary { get; set; }
        public int UserId { get; set; }
    }
}