using FluentValidation;

namespace TDM.Application.BasicInformation.Traffics.Commands.CreateTraffic
{
    public class UpdateTrafficCommandValidator : AbstractValidator<CreateTrafficCommand>
    {
        public UpdateTrafficCommandValidator()
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
