using FluentValidation;

namespace TDM.Application.Doc.Declarations.Commands.UpdateDeclaration
{
    public class UpdateDeclarationCommandValidator : AbstractValidator<UpdateDeclarationCommand>
    {
        public UpdateDeclarationCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Number)
            .NotEmpty()
            .MaximumLength(50);

            RuleFor(x => x.Date)
            .NotEmpty()
            .WithMessage("Start date is required.");

            RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage("Start date is required.");

            RuleFor(x => x.EndDate)
            .NotEmpty()
            .WithMessage("End date is required.");

            RuleFor(x => x.ConsigneeId)
                .NotEmpty()
                .WithMessage("Consignee Id is required.");
            
            RuleFor(x => x.ConsigneeRepId)
                .Must(id => !id.HasValue || id.Value != Guid.Empty)
                .WithMessage("Consignee rep Id cannot be empty.");

            RuleFor(x => x.TrafficId)
               .NotEmpty()
               .WithMessage("Traffic Id is required.");

            RuleFor(x => x.TerminalCode)
                .NotEmpty()
                .WithMessage("Terminal code is required.");
        }
    }
}
