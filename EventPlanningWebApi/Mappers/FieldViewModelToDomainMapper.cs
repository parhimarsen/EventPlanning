using EventPlanning.Domain.Models;
using EventPlanningWebApi.Models;

namespace EventPlanningWebApi.Mappers
{
    public static class FieldViewModelToDomainMapper
    {
        public static DomainField ToDomain(this FieldViewModel @this)
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