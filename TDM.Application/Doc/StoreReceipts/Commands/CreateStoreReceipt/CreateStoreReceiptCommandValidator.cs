using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.Manifests.Commands.CreateManifest;
using TDM.Application.Doc.StoreReceipt.Command.CreateStoreReceipt;
using TDM.Application.Doc.StoreReceiptGoods.Commands.CreateStoreReceiptGood;
using TDM.Domain.Enums;

namespace TDM.Application.Doc.StoreReceipts.Commands.CreateStoreReceipt
{
    public class CreateStoreReceiptCommandValidator : AbstractValidator<CreateStoreReceiptCommand>
    {
        public CreateStoreReceiptCommandValidator()
        {
            RuleFor(x => x.TerminalCode)
         .NotEmpty()
         .MaximumLength(50)
         .WithMessage("Terminal code is required.");

            RuleFor(x => x.IPASStoreReceiptNo)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("IPAS Store Receipt No is required.");

            RuleFor(x => x.IssueDate)
                .NotEmpty()
                .WithMessage("Issue date is required.");

            RuleFor(x => x)
                .Must(x => x.ConsigneeId != Guid.Empty || !string.IsNullOrWhiteSpace(x.ConsigneeNationalId))
                .WithMessage("Consignee id or national id is required.");

            RuleFor(x => x)
                .Must(x => x.ConsigneeRepId != Guid.Empty || !string.IsNullOrWhiteSpace(x.ConsigneeRepNationalId))
                .WithMessage("Consignee representative id or national id is required.");

            RuleFor(x => x.CargoTypeId)
                .NotEmpty()
                .WithMessage("Cargo type Id is required.");
                       

            RuleFor(x => x)
                .Must(x => x.TrafficId != Guid.Empty || !string.IsNullOrWhiteSpace(x.TrafficCode))
                .WithMessage("Traffic id or traffic code is required.");

            RuleFor(x => x)
                .Must(x => x.StoreReceiptStateId != Guid.Empty
                    || !string.IsNullOrWhiteSpace(x.StoreReceiptStateCode)
                    || !string.IsNullOrWhiteSpace(x.StoreReceiptStateName))
                .WithMessage("Store receipt state id, code or name is required.");

            RuleFor(x => x)
                .Must(x => x.ArrivalTypeId != Guid.Empty
                    || !string.IsNullOrWhiteSpace(x.ArrivalTypeCode)
                    || !string.IsNullOrWhiteSpace(x.ArrivalTypeName))
                .WithMessage("Arrival type id, code or name is required.");

            RuleFor(x => x.FirstDischargeDate)
                .NotNull()
                .WithMessage("First discharge date is required.");

            RuleFor(x => x.DeclarationId)
                .Must(id => id.HasValue && id.Value != Guid.Empty)
                .When(x => x.ArrivalTypeCode == "1")
                .WithMessage("Declaration id is required when arrival type code is '1'.");

            RuleFor(x => x)
            .Must(x => x.DeclarationId.HasValue || x.ManifestItemId.HasValue)
            .WithMessage("Either DeclarationId or ManifestItemId must be provided.");

            RuleFor(x => x)
                .Must(x =>
                    x.DeclarationId.HasValue ^ x.ManifestItemId.HasValue)
                .WithMessage("Provide either DeclarationId or ManifestItemId, but not both.");

            RuleForEach(x => x.StoreReceiptGoods)
                   .SetValidator(x => new CreateStoreReceiptGoodCommandValidator(x.CargoTypeId == CargoTypes.Bulk));
            RuleForEach(x => x.StoreReceiptContainers)
               .SetValidator(new CreateStoreReceiptContainerCommandValidator());

        }

    }
    public class CreateStoreReceiptGoodCommandValidator : AbstractValidator<CreateStoreReceiptGoodCommand>
    {
        public CreateStoreReceiptGoodCommandValidator(bool isBulk = false)
        {
            RuleFor(x => x)
                .Must(x => x.CommodityId != Guid.Empty || !string.IsNullOrWhiteSpace(x.HsCode))
                .WithMessage("Commodity id or HS code is required.");

            RuleFor(x => x)
                .Must(x => x.PackageId != Guid.Empty || !string.IsNullOrWhiteSpace(x.PackageTypeCode))
                .WithMessage("Package id or package type code is required.");

            RuleFor(x => x.PackNB)
                .GreaterThan(0)
                .When(_ => !isBulk)
                .WithMessage("Package quantity must be greater than zero.");

            RuleFor(x => x.PackNB)
                .GreaterThanOrEqualTo(0)
                .When(_ => isBulk)
                .WithMessage("Package quantity cannot be negative.");

            RuleFor(x => x.GrossWeight)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Gross weight cannot be negative.");

            RuleFor(x => x.NetWeight)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Net weight cannot be negative.");

            RuleFor(x => x.Volume)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Volume cannot be negative.");

        }
    }
    public class CreateStoreReceiptContainerCommandValidator : AbstractValidator<CreateStoreReceiptContainerCommand>
    {
        public CreateStoreReceiptContainerCommandValidator()
        {
            RuleFor(x => x)
                .Must(x => x.ContainerId != Guid.Empty ||
                    (!string.IsNullOrWhiteSpace(x.ContainerNo) && !string.IsNullOrWhiteSpace(x.ContainerTypeAndSizeCode)))
                .WithMessage("Container id or container number and type code are required.");

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
            
            RuleForEach(x => x.StoreReceiptContainerGoods)
             .SetValidator(new CreateStoreReceiptContainerGoodCommandValidator());

        }
    }
    public class CreateStoreReceiptContainerGoodCommandValidator : AbstractValidator<CreateStoreReceiptContainerGoodCommand>
    {
        public CreateStoreReceiptContainerGoodCommandValidator()
        {
            RuleFor(x => x)
                .Must(x => x.CommodityId != Guid.Empty || !string.IsNullOrWhiteSpace(x.HsCode))
                .WithMessage("Commodity id or HS code is required.");

            RuleFor(x => x)
                .Must(x => x.PackageId != Guid.Empty || !string.IsNullOrWhiteSpace(x.PackageTypeCode))
                .WithMessage("Package id or package type code is required.");

            RuleFor(x => x.PackNB)
                .GreaterThan(0)
                .WithMessage("Package quantity must be greater than zero.");

            RuleFor(x => x.GrossWeight)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Gross weight cannot be negative.");

            RuleFor(x => x.NetWeight)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Net weight cannot be negative.");

            RuleFor(x => x.Volume)
                .GreaterThan(0)
                .WithMessage("Volume must be greater than zero.");

        }
    }
}
