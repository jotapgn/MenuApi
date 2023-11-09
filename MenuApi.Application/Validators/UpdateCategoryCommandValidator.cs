using FluentValidation;
using MenuApi.Application.Commands.UpdateCategory;
using MenuApi.Application.Commands.UpdateMenu;

namespace MenuApi.Application.Validators
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("[Name] cannot be empty");

            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage("[Name] must be greater than or equal to 3 characters.");

            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("[Id] must be greater than 0");

        }
    }
}
