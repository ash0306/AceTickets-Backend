﻿using System.ComponentModel.DataAnnotations;

namespace MovieBookingBackend.Models.DTOs.User
{
    public class UserLoginDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
