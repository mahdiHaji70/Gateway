using FluentValidation;

namespace TDM.Application.BasicInformation.Cities.Commands.RemoveCity
{
    public class DeleteCityCommandValidator : AbstractValidator<DeleteCityCommand>
    {
        public DeleteCityCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
