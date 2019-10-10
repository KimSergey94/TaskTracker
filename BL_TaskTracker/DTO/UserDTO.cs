using DAL_TaskTracker.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL_TaskTracker.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
}