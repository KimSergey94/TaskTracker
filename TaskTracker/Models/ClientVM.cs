

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models
{
    public class ClientVM
    {
        [Key]
        [Required(ErrorMessage = "Client Id field is required")]
        [Display(Name = "Client Id")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Country field is required")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Address field is required")]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Company Name field is required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "User Id field is required")]
        [Display(Name = "User Id")]
        public int UserId { get; set; }
    }
}