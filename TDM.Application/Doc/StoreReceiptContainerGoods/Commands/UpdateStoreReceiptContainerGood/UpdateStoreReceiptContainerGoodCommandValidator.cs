using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace TDM.Application.Doc.StoreReceiptContainerGoods.Commands.UpdateStoreReceiptContainerGood
{
    public class UpdateStoreReceiptContainerGoodCommandValidator:AbstractValidator<UpdateStoreReceiptContainerGoodCommand>
    {
        public UpdateStoreReceiptContainerGoodCommandValidator()
        {
            RuleFor(x => x.Id)
             .NotEmpty();

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
