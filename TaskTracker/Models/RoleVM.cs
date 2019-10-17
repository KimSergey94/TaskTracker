using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskTracker.Models
{
    public class RoleVM
    {
        [Key]
        [Required(ErrorMessage = "Role Id field is required")]
        [Display(Name = "Role Id")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}