﻿using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Models
{
    public class UserVM
    {
        public int UserId { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public virtual RoleVM Role { get; set; }

    }
}