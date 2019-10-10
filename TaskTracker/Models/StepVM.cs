﻿
using BLL_TaskTracker.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models
{
    public class StepVM
    {
        [Key]
        public int StepId { get; set; }

        public int TaskId { get; set; }
        public string Message { get; set; }
        public bool IsCompleted { get; set; }

        public virtual ICollection<CommentDTO> Comments { get; set; }
    }
}