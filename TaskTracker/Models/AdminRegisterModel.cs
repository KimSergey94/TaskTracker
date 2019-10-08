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

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        //[DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        //[DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        //[Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}