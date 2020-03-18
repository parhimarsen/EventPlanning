using EventPlanningWebApi.Models;
using FluentValidation;

namespace EventPlanningWebApi.Validators
{
    public class EventViewModelValidator : AbstractValidator<EventViewModel>
    {
        public EventViewModelValidator()
        {
            When(_ => _ != null, () => { RuleFor(_ => _.Name).NotEmpty(); });
        }
    }
}