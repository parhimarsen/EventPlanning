using System.Collections.Generic;

namespace EventPlanning.Infrastructure.Models
{
    public class InfrastructureEvent
    {
        public InfrastructureEvent()
        {
            EventsFields = new List<InfrastructureEventFields>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string DateTime { get; set; }

        public List<InfrastructureEventFields> EventsFields { get; set; }

        public int UserId { get; set; }
    }
}
