using System;

namespace EventPlanning.Domain.Models
{
    public class DomainField
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
