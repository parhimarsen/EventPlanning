using EventPlanning.Domain.Models;
using EventPlanning.Infrastructure.Models;

namespace EventPlanning.DomainServices.Mappers
{
    public static class InfrastructureToDomainFieldMapper
    {
        public static DomainField ToDomain(this InfrastructureField @this)
        {
            return new DomainField()
            {
                Id = @this.Id,
                Name = @this.Name,
                Value = @this.Value
            };
        }
    }
}
