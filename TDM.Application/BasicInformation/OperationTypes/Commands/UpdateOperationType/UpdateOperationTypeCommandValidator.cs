using FluentValidation;

namespace TDM.Application.BasicInformation.OperationTypes.Commands.UpdateOperationType
{
    public class UpdateOperationTypeCommandValidator : AbstractValidator<UpdateOperationTypeCommand>
    {
        public UpdateOperationTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

            RuleFor(x => x.Code)
                .NotEmpty()
                .WithMessage("Code is required.");
            
        }
    }
}
