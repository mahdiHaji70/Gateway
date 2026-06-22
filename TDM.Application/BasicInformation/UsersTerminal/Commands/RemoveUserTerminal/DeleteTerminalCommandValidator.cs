using FluentValidation;

namespace TDM.Application.BasicInformation.UsersTerminal.Commands.RemoveUserTerminal
{
    public class DeleteUserTerminalCommandValidator : AbstractValidator<DeleteUserTerminalCommand>
    {
        public DeleteUserTerminalCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
