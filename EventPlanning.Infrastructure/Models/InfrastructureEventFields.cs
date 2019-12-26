
namespace EventPlanning.Infrastructure.Models
{
    public class InfrastructureEventFields
    {
        public int EventId { get; set; }

        public InfrastructureEvent Event { get; set; }

        public int FieldId { get; set; }

        public InfrastructureField Field { get; set; }

    }
}
