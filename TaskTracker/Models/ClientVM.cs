

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models
{
    public class ClientVM
    {
        [Key]

        public int ClientId { get; set; }



        [Required(ErrorMessage = "Country field is required")]
        public string Country { get; set; }
        public string Address { get; set; }


        [Required(ErrorMessage = "Company Name field is required")]
        public string CompanyName { get; set; }


        public int UserId { get; set; }

        public virtual ICollection<TaskVM> Tasks { get; set; }
    }
}