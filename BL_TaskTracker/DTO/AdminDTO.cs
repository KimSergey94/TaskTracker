using BL_TaskTracker.DTO;
using System.ComponentModel.DataAnnotations;

namespace BLL_TaskTracker.DTO
{
    public class AdminDTO
    {
        public int AdminId { get; set; }


        public int UserId { get; set; }
        public virtual UserDTO User { get; set; }

    }
}