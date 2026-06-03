using FluentValidation;

namespace TDM.Application.BasicInformation.Declarations.Commands.CreateDeclaration
{
    public class CreateDeclarationCommandValidator : AbstractValidator<CreateDeclarationCommand>
    {
        public CreateDeclarationCommandValidator()
        {
            RuleFor(x => x.Number)
            .NotEmpty()
            .MaximumLength(50);

            RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage("Start date is required.");

            RuleFor(x => x.EndDate)
            .NotEmpty()
            .WithMessage("End date is required.");

            RuleFor(x => x.ConsigneeId)
                .NotEmpty()
                .WithMessage("Consignee Id is required.");
            
            RuleFor(x => x.ConsigneerepId)
                .NotEmpty()
                .WithMessage("Consignee rep Id is required.");

            RuleFor(x => x.TrafficId)
                .NotEmpty()
                .WithMessage("Traffic Id is required.");

            RuleFor(x => x.TerminalCode)
                .NotEmpty()
                .WithMessage("Terminal code is required.");
        }
    }
}
