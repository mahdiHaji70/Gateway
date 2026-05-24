using FluentValidation;

namespace TDM.Application.BasicInformation.Packages.Commands.RemovePackage
{
    public class DeletePackageCommandValidator : AbstractValidator<DeletePackageCommand>
    {
        public DeletePackageCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
