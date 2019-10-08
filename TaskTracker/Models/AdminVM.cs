using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models
{
    public class AdminVM
    {
        public int AdminId { get; set; }


        public int UserId { get; set; }
        public virtual UserVM Role { get; set; }
    }
}