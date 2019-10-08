using System.ComponentModel.DataAnnotations;

namespace DAL_TaskTracker.Entities
{
    public class Admin
    {
        public int AdminId { get; set; }
        public int UserId { get; set; }
        public virtual User Role { get; set; }
    }

}