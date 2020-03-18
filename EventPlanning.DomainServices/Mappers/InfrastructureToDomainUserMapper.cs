using EventPlanning.Domain.Models;
using EventPlanning.Infrastructure.Models;

namespace EventPlanning.DomainServices.Mappers
{
    public static class InfrastructureToDomainUserMapper
    {
        public static DomainUser ToDomain(this InfrastructureUser @this)
        {
            return new DomainUser()
            {
                Id = @this.Id,
                Email = @this.Email,
                Password = @this.Password,
                Role = @this.Role
            };
        }
    }
}
