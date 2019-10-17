using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskTracker.Models
{
    public class ManagerRegisterModel
    {
        [Key]
        [Required(ErrorMessage = "Manager Id field is required")]
        [Display(Name = "Manager Id")]
        public int ManagerId { get; set; }

        [Required(ErrorMessage = "Employee Id field is required")]
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "User Id field is required")]
        [Display(Name = "User Id")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Role Id field is required")]
        [Display(Name = "Role Id")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Email Address field is required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password Confirmation field is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password Confirmation")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Country field is required")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Position field is required")]
        [Display(Name = "Position")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Salary field is required")]
        [Display(Name = "Salary")]
        public int Salary { get; set; }

    }
}