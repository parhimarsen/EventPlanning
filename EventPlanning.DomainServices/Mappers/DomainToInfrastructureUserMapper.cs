using EventPlanning.Domain.Models;
using EventPlanning.Infrastructure.Models;

namespace EventPlanning.DomainServices.Mappers
{
    public static class DomainToInfrastructureUserMapper
    {
        public static InfrastructureUser ToInfrastructure(this DomainUser @this)
        {
            return new InfrastructureUser()
            {
                Id = @this.Id,
                Email = @this.Email,
                Password = @this.Password,
                Role = @this.Role
            };
        }
    }
}
