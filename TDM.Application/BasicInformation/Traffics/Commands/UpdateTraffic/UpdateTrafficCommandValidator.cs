using FluentValidation;

namespace TDM.Application.BasicInformation.Traffics.Commands.UpdateTraffic
{
    public class UpdateTrafficCommandValidator : AbstractValidator<UpdateTrafficCommand>
    {
        public UpdateTrafficCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

            RuleFor(x => x.Code)
                .NotEmpty()
                .WithMessage("Code is required.");
            
        }
    }
}
