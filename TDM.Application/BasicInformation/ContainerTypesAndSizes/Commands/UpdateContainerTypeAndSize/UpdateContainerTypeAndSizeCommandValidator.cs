using FluentValidation;

namespace TDM.Application.BasicInformation.ContainerTypesAndSizes.Commands.UpdateContainerTypeAndSize
{
    public class UpdateContainerTypeAndSizeCommandValidator : AbstractValidator<UpdateContainerTypeAndSizeCommand>
    {
        public UpdateContainerTypeAndSizeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.TypeAndSize)
            .NotEmpty()
            .MaximumLength(200);

            RuleFor(x => x.TypeAndSizeCode)
                .NotEmpty()
                .WithMessage("Code is required.");
            
        }
    }
}
