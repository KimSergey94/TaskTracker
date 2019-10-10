using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_TaskTracker.Entities
{
    public class Admin
    {
        public int AdminId { get; set; }
        public int UserId { get; set; }
    }

}