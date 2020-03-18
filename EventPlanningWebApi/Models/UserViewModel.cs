using System;
using EventPlanningWebApi.Validators;
using FluentValidation.Attributes;

namespace EventPlanningWebApi.Models
{
    [Validator(typeof(UserViewModelValidator))]
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; } 
    }
}