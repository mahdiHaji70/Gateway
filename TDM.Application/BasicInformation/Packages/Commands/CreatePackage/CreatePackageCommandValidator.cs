using FluentValidation;

namespace TDM.Application.BasicInformation.Packages.Commands.CreatePackage
{
    public class CreatePackageCommandValidator : AbstractValidator<CreatePackageCommand>
    {
        public CreatePackageCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

            RuleFor(x => x.Code)
                .NotEmpty()
                .WithMessage("Code is required.");
            
        }
    }
}
