using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskTracker.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Имя")] public string Name { get; set; }

        [Required]
        [Display(Name = "Логин")] public string Login { get; set; }
        [Required] [DataType(DataType.Password)] [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}