using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskTracker.Models
{
    public class AdminRegisterModel
    {
        //[Key]
        public int AdminId { get; set; }
        public int UserId { get; set; }
        public virtual UserVM User { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please enter a valid email address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter your confirmation password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password Confirmation")]
        [Compare("Password", ErrorMessage = "Password confirmation and password must match.")]
        public string ConfirmPassword { get; set; }
    }
}