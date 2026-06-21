using FluentValidation;

namespace TDM.Application.BasicInformation.Traffics.Commands.CreateTraffic
{
    public class CreateTrafficCommandValidator : AbstractValidator<CreateTrafficCommand>
    {
        public CreateTrafficCommandValidator()
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
