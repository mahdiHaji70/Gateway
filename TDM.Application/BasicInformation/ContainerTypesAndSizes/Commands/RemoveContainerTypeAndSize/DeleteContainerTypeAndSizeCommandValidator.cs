using FluentValidation;

namespace TDM.Application.BasicInformation.ContainerTypesAndSizes.Commands.RemoveContainerTypeAndSize
{
    public class DeleteContainerTypeAndSizeCommandValidator : AbstractValidator<DeleteContainerTypeAndSizeCommand>
    {
        public DeleteContainerTypeAndSizeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
