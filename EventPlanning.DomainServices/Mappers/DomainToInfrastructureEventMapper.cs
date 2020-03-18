using EventPlanning.Domain.Models;
using EventPlanning.Infrastructure.Models;

namespace EventPlanning.DomainServices.Mappers
{
    public static class DomainToInfrastructureEventMapper
    {
        public static InfrastructureEvent ToInfrastructure(this DomainEvent @this)
        {
            return new InfrastructureEvent()
            {
                Id = @this.Id,
                Name = @this.Name,
                DateTime = @this.DateTime,
                UserId = @this.UserId
            };
        }
    }
}
