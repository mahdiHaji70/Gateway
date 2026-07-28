using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Declarations.Commands.CreateDeclaration;

namespace TDM.Application.Doc.StoreReceiptContainers.Commands.CreateStoreReceiptContainer
{
    public class CreateStoreReceiptContainerCommandValidator : AbstractValidator<CreateStoreReceiptContainerCommand>
    {
        public CreateStoreReceiptContainerCommandValidator()
        {
            RuleFor(x => x.StoreReceiptHeadId)
            .NotEmpty()
            .WithMessage("Store receipt head is required.");

            RuleFor(x => x.ContainerId)
                .NotEmpty()
                .WithMessage("Container is required.");

            RuleFor(x => x.SealNumber)
                .NotEmpty()
                .MaximumLength(100)
                .WithMessage("Seal number is required.");

            RuleFor(x => x.IgnitionTemperature)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Ignition temperature cannot be negative.");

            RuleFor(x => x)
                .Must(x => string.IsNullOrWhiteSpace(x.IgnitionTemperatureUnit) || x.IgnitionTemperature > 0)
                .WithMessage("Ignition temperature must be greater than zero when a unit is specified.");
        }
    }
}
