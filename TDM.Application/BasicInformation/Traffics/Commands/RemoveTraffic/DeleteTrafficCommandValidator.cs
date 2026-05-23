using FluentValidation;

namespace TDM.Application.BasicInformation.Traffics.Commands.RemoveTraffic
{
    public class DeleteTrafficCommandValidator : AbstractValidator<DeleteTrafficCommand>
    {
        public DeleteTrafficCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
