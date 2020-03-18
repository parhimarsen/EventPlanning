using EventPlanningWebApi.Models;
using FluentValidation;

namespace EventPlanningWebApi.Validators
{
    public class FieldViewModelValidator : AbstractValidator<FieldViewModel>
    {
        public FieldViewModelValidator()
        {
            When( _ => _ != null, () =>
            {
                RuleFor(_ => _.Name).NotEmpty();
                RuleFor(_ => _.Value).NotEmpty();
            });
        }
    }
}