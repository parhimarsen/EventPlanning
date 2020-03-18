using EventPlanning.Domain.Models;
using EventPlanning.Models;

namespace EventPlanning.Mappers
{
    public static class EventViewModelToDomainMapper
    {
        public static DomainEvent ToDomain(this EventViewModel @this)
        {
            return new DomainEvent()
            {
                Id = @this.Id,
                Name = @this.Name,
                DateTime = @this.DateTime,
                UserId = @this.UserId,
            };
        }
    }
}