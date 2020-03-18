using EventPlanningWebApi.Models;
using FluentValidation;

namespace EventPlanningWebApi.Validators
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            When(_ => _ != null, () =>
            {
                RuleFor(_ => _.Email).NotEmpty().NotNull();
                RuleFor(_ => _.Password).NotEmpty().NotNull();
                RuleFor(_ => _.Role).NotEmpty().NotNull();
            });
        }
    }
}