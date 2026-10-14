using FluentValidation;

namespace TDM.Application.BasicInformation.OperationTypes.Commands.RemoveOperationType
{
    public class DeleteOperationTypeCommandValidator : AbstractValidator<DeleteOperationTypeCommand>
    {
        public DeleteOperationTypeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
