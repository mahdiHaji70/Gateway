using FluentValidation;

namespace TDM.Application.BasicInformation.ContainerTypesAndSizes.Commands.CreateContainerTypeAndSize
{
    public class CreateContainerTypeAndSizeCommandValidator : AbstractValidator<CreateContainerTypeAndSizeCommand>
    {
        public CreateContainerTypeAndSizeCommandValidator()
        {
            RuleFor(x => x.TypeAndSize)
            .NotEmpty()
            .MaximumLength(200);

            RuleFor(x => x.TypeAndSizeCode)
                .NotEmpty()
                .WithMessage("Code is required.");
            
        }
    }
}
