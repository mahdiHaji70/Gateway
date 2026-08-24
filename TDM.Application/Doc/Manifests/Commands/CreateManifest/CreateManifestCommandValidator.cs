using FluentValidation;

namespace TDM.Application.Doc.Manifests.Commands.CreateManifest
{
    public class CreateManifestCommandValidator : AbstractValidator<CreateManifestCommand>
    {
        public CreateManifestCommandValidator()
        {
            RuleFor(x => x.SerialNo)
                .NotEmpty().WithMessage("Serial number is required.")
                .MaximumLength(50);

            RuleFor(x => x.ManifestRegistrationNumber)
                .NotEmpty().WithMessage("Manifest registration number is required.")
                .MaximumLength(50);

            RuleFor(x => x.VoyageNo)
                .NotEmpty().WithMessage("Voyage number is required.")
                .MaximumLength(50);

            RuleFor(x => x.NoticeNo)
                .NotEmpty().WithMessage("Notice number is required.")
                .MaximumLength(50);

            RuleFor(x => x.ETA)
                .NotEmpty().WithMessage("ETA is required.");

            RuleFor(x => x.ETD)
                .NotEmpty().WithMessage("ETD is required.")
                .GreaterThanOrEqualTo(x => x.ETA).WithMessage("ETD must be greater than or equal to ETA.");

            RuleFor(x => x.ShipLine)
                .NotEmpty().WithMessage("Ship line is required.")
                .MaximumLength(100);

            RuleFor(x => x.ShipAgent)
                .NotEmpty().WithMessage("Ship agent is required.")
                .MaximumLength(100);

            RuleFor(x => x.VesselName)
                .NotEmpty().WithMessage("Vessel name is required.")
                .MaximumLength(100);

            RuleFor(x => x.Imo)
                .NotEmpty().WithMessage("IMO is required.")
                .MaximumLength(20);

            RuleFor(x => x.TerminalCode)
                .NotEmpty().WithMessage("Terminal code is required.")
                .MaximumLength(20);

            RuleFor(x => x.ManifestItems)
                .NotNull().WithMessage("Manifest items collection cannot be null.")
                .NotEmpty().WithMessage("Manifest must contain at least one item.");

            RuleForEach(x => x.ManifestItems)
                .SetValidator(new CreateManifestItemCommandValidator());
        }
    }

    public class CreateManifestItemCommandValidator : AbstractValidator<CreateManifestItemCommand>
    {
        public CreateManifestItemCommandValidator()
        {
            RuleFor(x => x.ManifestItemNo)
                .NotEmpty().WithMessage("Manifest item number is required.")
                .MaximumLength(50);

            RuleFor(x => x.ManifestNo)
                .NotEmpty().WithMessage("Manifest number is required.")
                .MaximumLength(50);

            RuleFor(x => x.ShipLine)
                .MaximumLength(100);

            RuleFor(x => x.TrafficCode)
                .MaximumLength(50);

            RuleFor(x => x.ConsigneeNationalId)
                .NotEmpty().WithMessage("Consignee national ID is required.")
                .MaximumLength(20);

            RuleFor(x => x.ShipAgentNationalId)
                .NotEmpty().WithMessage("Ship agent national ID is required.")
                .MaximumLength(20);

            RuleFor(x => x.CargoTypeId)
               .NotEmpty().WithMessage("Cargo Type Id is required.");

            RuleForEach(x => x.ManifestGoods)
                .SetValidator(new CreateManifestGoodCommandValidator())
                .When(x => x.ManifestGoods != null);

            RuleForEach(x => x.ManifestContainers)
                .SetValidator(new CreateManifestContainerCommandValidator())
                .When(x => x.ManifestContainers != null);
        }
    }

    public class CreateManifestGoodCommandValidator : AbstractValidator<CreateManifestGoodCommand>
    {
        public CreateManifestGoodCommandValidator()
        {
            RuleFor(x => x.PackNb)
                .GreaterThanOrEqualTo(0).WithMessage("Package count  be negative.");

            RuleFor(x => x.GrossWeight)
                .GreaterThan(0).WithMessage("Gross weight must be greater than zero.");

            RuleFor(x => x.NetWeight)
                .GreaterThanOrEqualTo(0).WithMessage("Net weight cannot be negative.")
                .LessThanOrEqualTo(x => x.GrossWeight).WithMessage("Net weight cannot exceed gross weight.");

            RuleFor(x => x.Volume)
                .GreaterThanOrEqualTo(0).WithMessage("Volume cannot be negative.");

            RuleFor(x => x.HSCode)
                .NotEmpty().WithMessage("HS code is required.")
                .MaximumLength(20);

            RuleFor(x => x.PackageCode)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .When(x => x.PackNb > 0)
                .WithMessage("Package code is required.")
                .MaximumLength(20)
                .When(x => !string.IsNullOrWhiteSpace(x.PackageCode));

            RuleFor(x => x.Description)
                .MaximumLength(500);
        }
    }

    public class CreateManifestContainerCommandValidator : AbstractValidator<CreateManifestContainerCommand>
    {
        public CreateManifestContainerCommandValidator()
        {
            RuleFor(x => x.ContainerNo)
                .NotEmpty().WithMessage("Container number is required.")
                .Length(11).WithMessage("Container number must be exactly 11 characters.");

            RuleFor(x => x.SealNumber)
                .MaximumLength(50);

            RuleFor(x => x.DangerousCode)
                .MaximumLength(20);

            RuleFor(x => x.Classification)
                .MaximumLength(50);

            RuleFor(x => x.IgnitionTemperatureUnit)
                .MaximumLength(10);

            RuleForEach(x => x.ManifestContainerGoods)
                .SetValidator(new CreateManifestContainerGoodCommandValidator())
                .When(x => x.ManifestContainerGoods != null);
        }
    }

    public class CreateManifestContainerGoodCommandValidator : AbstractValidator<CreateManifestContainerGoodCommand>
    {
        public CreateManifestContainerGoodCommandValidator()
        {
            RuleFor(x => x.PackNb)
                .GreaterThanOrEqualTo(0).WithMessage("Package count be negative.");

            RuleFor(x => x.GrossWeight)
                .GreaterThan(0).WithMessage("Gross weight must be greater than zero.");

            RuleFor(x => x.NetWeight)
                .GreaterThanOrEqualTo(0).WithMessage("Net weight cannot be negative.")
                .LessThanOrEqualTo(x => x.GrossWeight).WithMessage("Net weight cannot exceed gross weight.");

            RuleFor(x => x.HSCode)
                .NotEmpty().WithMessage("HS code is required.")
                .MaximumLength(20);

            RuleFor(x => x.PackageCode)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .When(x => x.PackNb > 0)
                .WithMessage("Package code is required.")
                .MaximumLength(20)
                .When(x => !string.IsNullOrWhiteSpace(x.PackageCode));
        }
    }
}
