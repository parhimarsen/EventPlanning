
using System;

namespace EventPlanning.Infrastructure.Models
{
    public class InfrastructureEventFields
    {
        public Guid EventId { get; set; }

        public InfrastructureEvent Event { get; set; }

        public Guid FieldId { get; set; }

        public InfrastructureField Field { get; set; }

    }
}
