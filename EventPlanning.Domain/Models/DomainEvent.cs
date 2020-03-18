using System;

namespace EventPlanning.Domain.Models
{
    public class DomainEvent
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DateTime { get; set; }

        public Guid UserId { get; set; }
    }
}
