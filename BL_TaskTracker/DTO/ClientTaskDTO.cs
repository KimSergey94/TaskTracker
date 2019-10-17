using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_TaskTracker.DTO
{
    public class ClientTaskDTO
    {
        [Key]
        [Required(ErrorMessage = "Task Id field is required")]
        [Display(Name = "Task Id")]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Task Definition field is required")]
        [Display(Name = "Task Definition")]
        public string TaskDefinition { get; set; }

        [Required(ErrorMessage = "Manager Name field is required")]
        [Display(Name = "Manager Name")]
        public string ManagerName { get; set; }

        [Required(ErrorMessage = "Manager Email field is required")]
        [Display(Name = "Manager Email")]
        public string ManagerEmail { get; set; }
    }
}
