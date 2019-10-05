using System.ComponentModel.DataAnnotations;

namespace BLL_TaskTracker.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}