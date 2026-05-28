using FluentValidation;

namespace TDM.Application.BasicInformation.Cities.Commands.CreateCity
{
    public class UpdateCityCommandValidator : AbstractValidator<CreateCityCommand>
    {
        public UpdateCityCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

            RuleFor(x => x.Code)
                .NotEmpty()
                .WithMessage("Code is required.");

            RuleFor(x => x.CountryId)
                .NotEmpty()
                .WithMessage("Country is required.");
            
        }
    }
}
