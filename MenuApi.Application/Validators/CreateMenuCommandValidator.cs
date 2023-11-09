using FluentValidation;
using MenuApi.Application.Commands.CreateMenu;
using MenuApi.Domain.Enum;

namespace MenuApi.Application.Validators
{
    public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
    {
        public CreateMenuCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("[Name] cannot be empty");

            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage("[Name] must be greater than or equal to 3 characters.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("[Description] cannot be empty");

            RuleFor(x => x.Description)
                .MinimumLength(3)
                .WithMessage("[Description] must be greater than or equal to 3 characters.");

            RuleFor(x => x.Status)
                 .Must(ValidateStatusMenu)
                 .WithMessage("Invalid Status.");
        }
        public bool ValidateStatusMenu(StatusMenu status)
        {
            return Enum.IsDefined(typeof(StatusMenu), status.GetHashCode());

        }
    }
}
