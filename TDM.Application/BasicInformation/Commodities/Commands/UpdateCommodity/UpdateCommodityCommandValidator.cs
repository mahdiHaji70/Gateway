using FluentValidation;
using TDM.Application.BasicInformation.Commodities.Commands.UpdateCommodity;
using TDM.Domain.Enums;

namespace TDM.Application.BasicInformation.Commodities.Commands.UpdateCommodity
{
    public class UpdateCommodityCommandValidator : AbstractValidator<UpdateCommodityCommand>
    {
        public UpdateCommodityCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

            RuleFor(x => x.HSCode)
                .NotEmpty()
                .Length(8)
                .WithMessage("HS code should have 8 digits");
            
        }
    }
}
