using EventPlanning.Domain.Models;
using EventPlanning.Infrastructure.Models;

namespace EventPlanning.DomainServices.Mappers
{
    public static class InfrastructureToDomainEventMapper
    {
        public static DomainEvent ToDomain(this InfrastructureEvent @this)
        {
            return new DomainEvent()
            {
                Id = @this.Id,
                Name = @this.Name,
                DateTime = @this.DateTime,
                UserId = @this.UserId
            };
        }
    }
}
