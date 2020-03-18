﻿using System.ComponentModel.DataAnnotations;

namespace EventPlanningWebApi.Models
{
    public class RegistrationViewModel
    {
        [Required]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password not specified")]
        [Compare("Password", ErrorMessage = "Password entered is incorrect")]
        public string ConfirmPassword { get; set; }
    }
}