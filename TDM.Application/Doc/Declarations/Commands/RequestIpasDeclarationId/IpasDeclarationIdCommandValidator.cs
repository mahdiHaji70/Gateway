using FluentValidation;

namespace TDM.Application.Doc.Declarations.Commands.RequestIpasDeclarationId
{
    public class IpasDeclarationIdCommandValidator : AbstractValidator<IpasDeclarationIdCommand>
    {
        public IpasDeclarationIdCommandValidator()
        {
            RuleFor(x => x.DeclarationId)
                .NotEmpty();
        }
    }
}
