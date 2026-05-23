using FluentValidation;

namespace TDM.Application.BasicInformation.Commodities.Commands.CreateCommodity
{
    public class UpdateCommodityCommandValidator : AbstractValidator<CreateCommodityCommand>
    {
        public UpdateCommodityCommandValidator()
        {
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
