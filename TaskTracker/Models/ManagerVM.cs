using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models
{
    public class ManagerVM 
    {
        [Key]
        [Required(ErrorMessage = "Manager Id field is required")]
        [Display(Name = "Manager Id")]
        public int ManagerId { get; set; }

        [Required(ErrorMessage = "Employee Id field is required")]
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }

    }
}