using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskTracker.Models
{
    public class ClientRegisterModel
    {
        [Required(ErrorMessage = "Client Id field is required")]
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        
        [Required(ErrorMessage = "Email field is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Company Name field is required")]
        public string CompanyName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}