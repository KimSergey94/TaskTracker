using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models
{
    public class UserVM
    {
        [Key]

        [Required(ErrorMessage = "User Id field is required")]
        [Display(Name = "User Id")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Email Address field is required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role Id field is required")]
        [Display(Name = "Role Id")]
        public int RoleId { get; set; }

    }
}