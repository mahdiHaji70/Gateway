using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.CargoTypes.Commands.CreateCargoType;
using TDM.Domain.Entities;
using TDM.Domain.Exceptions;

namespace TDM.Application.Doc.StoreReceiptGoods.Commands.CreateStoreReceiptGood
{
  
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
}
