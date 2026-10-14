using FluentValidation;

namespace TDM.Application.BasicInformation.OperationTypes.Commands.CreateOperationType
{
    public class CreateOperationTypeCommandValidator : AbstractValidator<CreateOperationTypeCommand>
    {
        public CreateOperationTypeCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

            RuleFor(x => x.Code)
                .NotEmpty()
                .WithMessage("Code is required.");
            
        }
    }
}
