using System.ComponentModel.DataAnnotations;

namespace DAL_TaskTracker.Entities
{
    public class User
    {
        public int UserId { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

    }
}