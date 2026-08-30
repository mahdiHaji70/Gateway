using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Doc.Manifests.Commands.CreateManifest;
using TDM.Application.Doc.StoreReceipt.Command.CreateStoreReceipt;
using TDM.Application.Doc.StoreReceiptGoods.Commands.CreateStoreReceiptGood;

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

            RuleFor(x => x.ConsigneeId)
                .NotEmpty()
                .WithMessage("Consignee Id is required.");

            RuleFor(x => x.ConsigneeRepId)
                .NotEmpty()
                .WithMessage("Consignee representative Id is required.");

            RuleFor(x => x.CargoTypeId)
                .NotEmpty()
                .WithMessage("Cargo type Id is required.");

            RuleFor(x => x.CreatorId)
                .NotEmpty()
                .WithMessage("Creator Id is required.");

            RuleFor(x => x.TrafficId)
                .NotEmpty()
                .WithMessage("Traffic Id is required.");

            RuleFor(x => x.StoreReceiptStateId)
                .NotEmpty()
                .WithMessage("Store receipt state Id is required.");

            RuleFor(x => x.ArrivalTypeId)
                .NotEmpty()
                .WithMessage("Arrival type Id is required.");

            RuleFor(x => x.FirstDischargeDate)
                .NotNull()
                .WithMessage("First discharge date is required.");

            RuleFor(x => x)
            .Must(x => x.DeclarationId.HasValue || x.BillOfLadingId.HasValue)
            .WithMessage("Either DeclarationId or BillOfLadingId must be provided.");

            RuleFor(x => x)
                .Must(x =>
                    x.DeclarationId.HasValue ^ x.BillOfLadingId.HasValue)
                .WithMessage("Provide either DeclarationId or BillOfLadingId, but not both.");

            RuleForEach(x => x.StoreReceiptGoods)
                   .SetValidator(new CreateStoreReceiptGoodCommandValidator());
            RuleForEach(x => x.StoreReceiptContainers)
               .SetValidator(new CreateStoreReceiptContainerCommandValidator());

        }

    }
    public class CreateStoreReceiptGoodCommandValidator : AbstractValidator<CreateStoreReceiptGoodCommand>
    {
        public CreateStoreReceiptGoodCommandValidator()
        {
            RuleFor(x => x.CommodityId)
                .NotEmpty()
                .WithMessage("Commodity is required.");

            RuleFor(x => x.PackageId)
                .NotEmpty()
                .WithMessage("Package is required.");

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
            
            RuleForEach(x => x.StoreReceiptContainerGoods)
             .SetValidator(new CreateStoreReceiptContainerGoodCommandValidator());

        }
    }
    public class CreateStoreReceiptContainerGoodCommandValidator : AbstractValidator<CreateStoreReceiptContainerGoodCommand>
    {
        public CreateStoreReceiptContainerGoodCommandValidator()
        {
            RuleFor(x => x.CommodityId)
                .NotEmpty()
                .WithMessage("Commodity is required.");

            RuleFor(x => x.PackageId)
                .NotEmpty()
                .WithMessage("Package is required.");

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
