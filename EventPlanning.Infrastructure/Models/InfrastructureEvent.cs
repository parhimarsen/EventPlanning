using System;
using System.Collections.Generic;

namespace EventPlanning.Infrastructure.Models
{
    public class InfrastructureEvent
    {
        public InfrastructureEvent()
        {
            EventsFields = new List<InfrastructureEventFields>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DateTime { get; set; }

        public Guid UserId { get; set; }

        public InfrastructureUser User { get; set; }

        public List<InfrastructureEventFields> EventsFields { get; set; }
    }
}
