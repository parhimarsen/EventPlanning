using System;

namespace EventPlanning.Infrastructure.Models
{
    public class InfrastructureUser
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
