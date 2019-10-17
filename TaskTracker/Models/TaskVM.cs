using BLL_TaskTracker.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models
{
    public class TaskVM
    {
        [Key]
        [Required(ErrorMessage = "Task Id field is required")]
        [Display(Name = "Task Id")]
        public int TaskId { get; set; }


        [Required(ErrorMessage = "IsCompleted value is required")]
        [Display(Name = "Is Completed?")]
        public bool IsCompleted { get; set; }


        [Required(ErrorMessage = "Task Definition field is required")]
        [Display(Name = "Task Definition")]
        public string TaskDefinition { get; set; }


        [Required(ErrorMessage = "Number Of Steps field is required")]
        [Display(Name = "Number Of Steps")]
        public int NumberOfSteps { get; set; }


        [Required(ErrorMessage = "Task Percentage field is required")]
        [Display(Name = "Task Percentage")]
        public int TaskPercentage { get; set; }


        [Required(ErrorMessage = "Manager Id field is required")]
        [Display(Name = "Manager Id")]
        public int ManagerId { get; set; }


        [Required(ErrorMessage = "Employee Id field is required")]
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }


        [Required(ErrorMessage = "Client Id field is required")]
        [Display(Name = "Client Id")]
        public int ClientId { get; set; }

        public virtual ICollection<StepDTO> Steps { get; set; }
    }
}