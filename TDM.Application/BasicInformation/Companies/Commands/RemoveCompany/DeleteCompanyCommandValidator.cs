using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Companies.Commands.UpdateCompany;

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
