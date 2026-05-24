using FluentValidation;

namespace TDM.Application.BasicInformation.Countries.Commands.RemoveCountry
{
    public class DeleteCountryCommandValidator : AbstractValidator<DeleteCountryCommand>
    {
        public DeleteCountryCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
