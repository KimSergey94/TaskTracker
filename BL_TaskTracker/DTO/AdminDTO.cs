using System.ComponentModel.DataAnnotations;

namespace BLL_TaskTracker.DTO
{
    public class AdminDTO
    {
        public int AdminId { get; set; }
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
    }
}