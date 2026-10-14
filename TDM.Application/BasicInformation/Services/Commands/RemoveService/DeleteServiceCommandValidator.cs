using FluentValidation;

namespace TDM.Application.BasicInformation.Services.Commands.RemoveService
{
    public class DeleteServiceCommandValidator : AbstractValidator<DeleteServiceCommand>
    {
        public DeleteServiceCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
