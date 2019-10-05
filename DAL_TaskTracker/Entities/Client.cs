using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskTracker.Models
{
    public class Client
    {
        [Required(ErrorMessage = "Client Id field is required")]
        public int ClientId { get; set; }
        [Required(ErrorMessage = "Company Name field is required")]
        public string CompanyName{ get; set; }
        [Required(ErrorMessage = "Email field is required")]
        public string Email { get; set; }
    }
}