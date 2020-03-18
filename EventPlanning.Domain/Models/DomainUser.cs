using System;

namespace EventPlanning.Domain.Models
{
    public class DomainUser
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
