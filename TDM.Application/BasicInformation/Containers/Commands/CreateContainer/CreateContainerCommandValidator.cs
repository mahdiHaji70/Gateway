using FluentValidation;

namespace TDM.Application.BasicInformation.Containers.Commands.CreateContainer
{
    public class CreateContainerCommandValidator : AbstractValidator<CreateContainerCommand>
    {
        public CreateContainerCommandValidator()
        {
            RuleFor(x => x.No)
            .NotEmpty()
            .MaximumLength(20);
            
            RuleFor(x => x.ContainerTypeAndSizeId)
                .NotEmpty()
                .WithMessage("Container Type And Size is required.");
            
        }
    }
}
