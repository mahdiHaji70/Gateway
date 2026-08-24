using System;
using FluentValidation;

namespace TDM.Application.Operation.VesselDischarges.Commands.CreateVesselDischarge
{
    public class CreateVesselDischargeCommandValidator
        : AbstractValidator<CreateVesselDischargeCommand>
    {
        public CreateVesselDischargeCommandValidator()
        {
            RuleFor(x => x.TerminalCode)
                .NotEmpty()
                .WithMessage("TerminalCode is required.")
                .MaximumLength(4)
                .WithMessage("TerminalCode must not exceed 4 characters.");

            RuleFor(x => x.StoreId)
                .NotEmpty()
                .WithMessage("StoreId is required.");

            RuleFor(x => x.ManifestItemId)
                .NotEmpty()
                .WithMessage("ManifestItemId is required.");

            RuleFor(x => x.DischargeDate)
                .NotEmpty()
                .WithMessage("DischargeDate is required.")
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("DischargeDate cannot be in the future.");

            RuleFor(x => x.PackNB)
                .GreaterThan(0)
                .WithMessage("PackNB must be greater than zero.");

            RuleFor(x => x.Weight)
                .GreaterThan(0)
                .WithMessage("Weight must be greater than zero.");

            RuleFor(x => x.Volume)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Volume cannot be negative.");

            RuleFor(x => x.UnitWeight)
                .GreaterThanOrEqualTo(0)
                .WithMessage("UnitWeight cannot be negative.");

            RuleFor(x => x.DangerousCode)
                .NotEmpty()
                .When(x => x.IsDangerous)
                .WithMessage("DangerousCode is required when cargo is dangerous.")
                .MaximumLength(100)
                .When(x => !string.IsNullOrWhiteSpace(x.DangerousCode))
                .WithMessage("DangerousCode must not exceed 100 characters.");

            RuleFor(x => x.Classification)
                .MaximumLength(100)
                .When(x => !string.IsNullOrWhiteSpace(x.Classification))
                .WithMessage("Classification must not exceed 100 characters.");

            RuleFor(x => x.IgnitionTemperature)
                .GreaterThan(0)
                .When(x => x.IsDangerous)
                .WithMessage("IgnitionTemperature must be greater than zero when cargo is dangerous.");

            RuleFor(x => x.IgnitionTemperatureUnit)
                .NotEmpty()
                .When(x => x.IsDangerous)
                .WithMessage("IgnitionTemperatureUnit is required when cargo is dangerous.")
                .MaximumLength(20)
                .When(x => !string.IsNullOrWhiteSpace(x.IgnitionTemperatureUnit))
                .WithMessage("IgnitionTemperatureUnit must not exceed 20 characters.");

        }
    }
}
