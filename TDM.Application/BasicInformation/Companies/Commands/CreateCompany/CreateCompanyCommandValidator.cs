using FluentValidation;
using TDM.Domain.Enums;

namespace TDM.Application.BasicInformation.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

            RuleFor(x => x.NationalId)
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.RegisterDate)
            .NotEmpty()
            .WithMessage("Register date is required.");

            RuleFor(x => x.Mobile)
                .NotEmpty()
                .Matches(@"^09\d{9}$")
                .WithMessage("Mobile should start with 09 and it has 11 digits long");

            RuleFor(x => x.Address)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.PostCode)
                .NotEmpty()
                .MaximumLength(10);

            RuleFor(x => x.EconomicCode)
                .NotEmpty()
                .When(x => x.CompanyType == CompanyType.Company);

            RuleFor(x => x.EconomicCode)
                .Empty()
                .When(x => x.CompanyType == CompanyType.Person)
                .WithMessage("Economic code is not permitted for persons.");
        }
    }
}
