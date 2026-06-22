using FluentValidation;

namespace TDM.Application.BasicInformation.UsersTerminal.Commands.UpdateUserTerminal
{
    public class UpdateUserTerminalCommandValidator : AbstractValidator<UpdateUserTerminalCommand>
    {
        public UpdateUserTerminalCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.UserNationalId)
                        .NotEmpty()
                        .MaximumLength(15);

            RuleFor(x => x.TerminalId)
                .NotEmpty()
                .WithMessage("UserTerminal Id is required.");
        }
    }
}
