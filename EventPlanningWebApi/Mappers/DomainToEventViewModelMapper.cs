using EventPlanning.Domain.Models;
using EventPlanningWebApi.Models;

namespace EventPlanningWebApi.Mappers
{
    public static class DomainToEventViewModelMapper
    {
        public static EventViewModel ToView(this DomainEvent @this)
        {
            return new EventViewModel()
            {
                Id = @this.Id,
                Name = @this.Name,
                DateTime = @this.DateTime,
                UserId = @this.UserId,
            };
        }
    }
}