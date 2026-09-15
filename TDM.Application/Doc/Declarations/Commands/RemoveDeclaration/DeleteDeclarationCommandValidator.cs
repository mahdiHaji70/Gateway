using FluentValidation;

namespace TDM.Application.Doc.Declarations.Commands.RemoveDeclaration
{
    public class DeleteDeclarationCommandValidator : AbstractValidator<DeleteDeclarationCommand>
    {
        public DeleteDeclarationCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
