﻿using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models
{
    public class AdminVM
    {
        [Key]

        public int AdminId { get; set; }


        public int UserId { get; set; }
    }
}