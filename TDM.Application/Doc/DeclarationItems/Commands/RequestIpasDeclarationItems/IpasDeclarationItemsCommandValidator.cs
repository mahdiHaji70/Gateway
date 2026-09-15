using FluentValidation;

namespace TDM.Application.Doc.DeclarationItems.Commands.RequestIpasDeclarationItems
{
    public class IpasDeclarationItemsCommandValidator : AbstractValidator<IpasDeclarationItemsCommand>
    {
        public IpasDeclarationItemsCommandValidator()
        {
            RuleFor(x => x.DeclarationId)
                .NotEmpty();
        }
    }
}
