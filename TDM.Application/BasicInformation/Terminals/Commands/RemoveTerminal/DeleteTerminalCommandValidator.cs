using FluentValidation;

namespace TDM.Application.BasicInformation.Terminals.Commands.RemoveTerminal
{
    public class DeleteTerminalCommandValidator : AbstractValidator<DeleteTerminalCommand>
    {
        public DeleteTerminalCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
