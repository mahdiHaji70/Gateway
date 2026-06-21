using FluentValidation;

namespace TDM.Application.BasicInformation.Terminals.Commands.CreateTerminal
{
    public class UpdateTerminalCommandValidator : AbstractValidator<CreateTerminalCommand>
    {
        public UpdateTerminalCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

            RuleFor(x => x.Code)
                .NotEmpty()
                .WithMessage("Code is required.")
                .MaximumLength(20)
                .WithMessage("Maximum length for Code is 20 charecters.");

            RuleFor(x => x.PortCode)
                .NotEmpty()
                .WithMessage("Code is required.")
                .MaximumLength(20)
                .WithMessage("Maximum length for PortCode is 20 charecters.");


            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Code is required.")
                .MaximumLength(20)
                .WithMessage("Maximum length for Username is 20 charecters.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Code is required.")
                .MaximumLength(20)
                .WithMessage("Maximum length for Password is 20 charecters.");
        }
    }
}
