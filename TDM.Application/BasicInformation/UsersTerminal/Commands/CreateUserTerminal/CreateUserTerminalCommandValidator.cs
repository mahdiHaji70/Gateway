using FluentValidation;

namespace TDM.Application.BasicInformation.UsersTerminal.Commands.CreateUserTerminal
{
    public class CreateUserTerminalCommandValidator : AbstractValidator<CreateUserTerminalCommand>
    {
        public CreateUserTerminalCommandValidator()
        {
            RuleFor(x => x.UserNationalId)
            .NotEmpty()
            .MaximumLength(15);

            RuleFor(x => x.TerminalId)
                .NotEmpty()
                .WithMessage("Terminal Id is required.");                
            
        }
    }
}
