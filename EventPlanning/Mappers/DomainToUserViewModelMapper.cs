using EventPlanning.Domain.Models;
using EventPlanning.Models;

namespace EventPlanning.Mappers
{
    public static class DomainToUserViewModelMapper
    {
        public static UserViewModel ToView(this DomainUser @this)
        {
            return new UserViewModel()
            {
                Id = @this.Id,
                Email = @this.Email,
                Password = @this.Password
            };
        }
    }
}