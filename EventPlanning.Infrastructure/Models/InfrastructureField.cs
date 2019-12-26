using System.Collections.Generic;

namespace EventPlanning.Infrastructure.Models
{
    public class InfrastructureField
    {
        public InfrastructureField()
        {
            EventsFields = new List<InfrastructureEventFields>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public List<InfrastructureEventFields> EventsFields { get; set; }
    }
}
