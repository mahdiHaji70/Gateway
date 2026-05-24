using FluentValidation;

namespace TDM.Application.BasicInformation.Countries.Commands.CreateCountry
{
    public class UpdateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
    {
        public UpdateCountryCommandValidator()
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
