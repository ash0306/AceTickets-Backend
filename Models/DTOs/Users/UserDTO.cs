﻿using System.ComponentModel.DataAnnotations;

namespace MovieBookingBackend.Models.DTOs.Users
{
    public class UserDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
