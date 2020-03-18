using EventPlanning.Domain.Models;
using EventPlanningWebApi.Models;

namespace EventPlanningWebApi.Mappers
{
    public static class UserViewModelToDomainMapper
    {
        public static DomainUser ToDomain(this UserViewModel @this)
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