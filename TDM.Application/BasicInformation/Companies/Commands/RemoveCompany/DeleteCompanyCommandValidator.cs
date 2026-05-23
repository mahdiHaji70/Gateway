using FluentValidation;

namespace TDM.Application.BasicInformation.Companies.Commands.RemoveCompany
{
    public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
    {
        public DeleteCompanyCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
