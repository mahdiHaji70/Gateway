using FluentValidation;
using TDM.Application.BasicInformation.Packages.Commands.CreatePackage;

namespace TDM.Application.BasicInformation.Packages.Commands.CreatePackage
{
    public class UpdatePackageCommandValidator : AbstractValidator<CreatePackageCommand>
    {
        public UpdatePackageCommandValidator()
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
