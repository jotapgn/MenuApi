using FluentValidation;
using MenuApi.Application.Commands.UpdateProduct;

namespace MenuApi.Application.Validators
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
              .GreaterThan(0)
              .WithMessage("[Id] must be greater than 0");

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

            RuleFor(x => x.Price)
              .GreaterThan(0)
              .WithMessage("[Price] must be greater than 0");

            RuleFor(x => x.MenuId)
              .GreaterThan(0)
              .WithMessage("[Price] must be greater than 0");

            RuleFor(x => x.CategoryId)
              .GreaterThan(0)
              .WithMessage("[Price] must be greater than 0");
        }
    }
}
