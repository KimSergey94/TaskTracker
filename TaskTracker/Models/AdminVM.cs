using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models
{
    public class AdminVM
    {
        public int AdminId { get; set; }
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
    }
}