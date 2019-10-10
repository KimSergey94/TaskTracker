using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL_TaskTracker.DTO
{
    public class AdminDTO
    {
        public int AdminId { get; set; }
        public int UserId { get; set; }
        //[ForeignKey("UserId")]
        //public virtual UserDTO User { get; set; }

    }
}