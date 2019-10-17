

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models
{
    public class EmployeeVM
    {
        [Key]
        [Required(ErrorMessage = "Employee Id is required")]
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }


        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Country field is required")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Position is required")]
        [Display(Name = "Position")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Salary field is required")]
        [Display(Name = "Salary")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "User Id is required")]
        [Display(Name = "User Id")]
        public int UserId { get; set; }

    }
}