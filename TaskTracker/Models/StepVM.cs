
using BLL_TaskTracker.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models
{
    public class StepVM
    {
        [Key]
        [Required(ErrorMessage = "Step Id field is required")]
        [Display(Name = "Step Id")]
        public int StepId { get; set; }

        [Required(ErrorMessage = "Task Id field is required")]
        [Display(Name = "Task Id")]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Message field is required")]
        [Display(Name = "Message")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Is Completed field is required")]
        [Display(Name = "Is Completed?")]
        public bool IsCompleted { get; set; }

        public virtual ICollection<CommentDTO> Comments { get; set; }
    }
}