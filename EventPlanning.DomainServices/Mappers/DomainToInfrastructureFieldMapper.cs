using EventPlanning.Domain.Models;
using EventPlanning.Infrastructure.Models;

namespace EventPlanning.DomainServices.Mappers
{
    public static class DomainToInfrastructureFieldMapper
    {
        public static InfrastructureField ToInfrastructure(this DomainField @this)
        {
            return new InfrastructureField()
            {
                Id = @this.Id,
                Name = @this.Name,
                Value = @this.Value
            };
        }
    }
}
