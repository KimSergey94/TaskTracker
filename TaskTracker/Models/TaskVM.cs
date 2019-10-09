using BLL_TaskTracker.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models
{
    public class TaskVM
    {
        [Key]
        public int TaskId { get; set; }

        public bool IsCompleted { get; set; }
        [Required]
        public string TaskDefinition { get; set; }

        [Required]
        public int NumberOfSteps { get; set; }

        [Required]
        public int ManagerId { get; set; }
        [Required]
        public int EmployeeId { get; set; }

        public int ClientId { get; set; }

        public virtual ICollection<StatusDTO> Statuses { get; set; }
    }
}