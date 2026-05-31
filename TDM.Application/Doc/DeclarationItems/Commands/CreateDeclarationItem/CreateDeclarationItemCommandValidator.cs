using FluentValidation;

namespace TDM.Application.BasicInformation.DeclarationItems.Commands.CreateDeclarationItem
{
    public class CreateDeclarationItemCommandValidator : AbstractValidator<CreateDeclarationItemCommand>
    {
        public CreateDeclarationItemCommandValidator()
        {
            RuleFor(x => x.Quantity)
               .GreaterThan(0)
               .WithMessage("Quantity must be greater than zero.");

            RuleFor(x => x.GrossWeight)
                .GreaterThan(0)
                .WithMessage("Gross weight must be greater than zero.");

            RuleFor(x => x.NetWeight)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Net weight cannot be negative.");

            When(x => x.GrossWeight > 0, () =>
            {
                RuleFor(x => x.NetWeight)
                    .LessThanOrEqualTo(x => x.GrossWeight)
                    .WithMessage("Net weight cannot be greater than gross weight.");
            });

            RuleFor(x => x.CommodityId)
                .NotEmpty()
                .WithMessage("CommodityId is required.");

            RuleFor(x => x.PackageId)
                .NotEmpty()
                .WithMessage("PackageId is required.");
        }
    }
}
