using FluentValidation;

namespace TDM.Application.BasicInformation.Cities.Commands.UpdateCity
{
    public class UpdateCityCommandValidator : AbstractValidator<UpdateCityCommand>
    {
        public UpdateCityCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

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
