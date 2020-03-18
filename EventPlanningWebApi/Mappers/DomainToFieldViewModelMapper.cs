using EventPlanning.Domain.Models;
using EventPlanningWebApi.Models;

namespace EventPlanningWebApi.Mappers
{
    public static class DomainToFieldViewModelMapper
    {
        public static FieldViewModel ToView(this DomainField @this)
        {
            return new FieldViewModel()
            {
                Id = @this.Id,
                Name = @this.Name,
                Value = @this.Value,
            };
        }
    }
}