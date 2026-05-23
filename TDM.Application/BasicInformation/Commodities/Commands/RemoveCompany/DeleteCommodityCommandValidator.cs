using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Companies.Commands.UpdateCompany;

namespace TDM.Application.BasicInformation.Companies.Commands.RemoveCommodity
{
    public class DeleteCommodityCommandValidator : AbstractValidator<DeleteCommodityCommand>
    {
        public DeleteCommodityCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
