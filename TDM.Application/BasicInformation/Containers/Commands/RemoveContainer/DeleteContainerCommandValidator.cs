using FluentValidation;

namespace TDM.Application.BasicInformation.Containers.Commands.RemoveContainer
{
    public class DeleteContainerCommandValidator : AbstractValidator<DeleteContainerCommand>
    {
        public DeleteContainerCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
