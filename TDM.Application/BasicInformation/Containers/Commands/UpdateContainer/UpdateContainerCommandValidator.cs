using FluentValidation;

namespace TDM.Application.BasicInformation.Containers.Commands.UpdateContainer
{
    public class UpdateContainerCommandValidator : AbstractValidator<UpdateContainerCommand>
    {
        public UpdateContainerCommandValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty();

            RuleFor(x => x.No)
            .NotEmpty()
            .MaximumLength(20);

            RuleFor(x => x.ContainerTypeAndSizeId)
                .NotEmpty()
                .WithMessage("Container Type And Size is required.");

        }
    }
}
