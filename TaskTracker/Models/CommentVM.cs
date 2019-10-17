using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models
{
    public class CommentVM
    {
        [Key]
        [Required(ErrorMessage = "Client Id field is required")]
        [Display(Name = "Client Id")]
        public int CommentId { get; set; }

        [Required(ErrorMessage = "Step Id field is required")]
        [Display(Name = "Step Id")]
        public int StepId { get; set; }

        [Required(ErrorMessage = "Message field is required")]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}
