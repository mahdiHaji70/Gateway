using FluentValidation;

namespace TDM.Application.Doc.Voyages.Commands.RemoveVoyage
{
    public class DeleteVoyageCommandValidator : AbstractValidator<DeleteVoyageCommand>
    {
        public DeleteVoyageCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
