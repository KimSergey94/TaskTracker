using System.ComponentModel.DataAnnotations;

namespace DAL_TaskTracker.Entities
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
    }
}