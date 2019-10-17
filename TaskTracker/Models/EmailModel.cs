using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskTracker.Models
{
    public class EmailModel
    {
        [Key]
        [Required(ErrorMessage = "Client Id field is required")]
        [Display(Name = "Client Id")]
        public int EmailId { get; set; }

        [Required(ErrorMessage = "Client Id field is required")]
        [Display(Name = "Client Id")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Task Id field is required")]
        [Display(Name = "Task Id")]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Manager Id field is required")]
        [Display(Name = "Manager Id")]
        public int ManagerId { get; set; }

    }
}