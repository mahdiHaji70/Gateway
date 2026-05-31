using FluentValidation;

namespace TDM.Application.BasicInformation.DeclarationItems.Commands.RemoveDeclarationItem
{
    public class DeleteDeclarationItemCommandValidator : AbstractValidator<DeleteDeclarationItemCommand>
    {
        public DeleteDeclarationItemCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
