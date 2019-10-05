using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models
{
    public class AdminVM
    {
        public int AdminVMId { get; set; }
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
    }
}