using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.CargoTypes.Commands.DeleteCargoType;

namespace TDM.Application.Doc.StoreReceiptGoods.Commands.DeleteStoreReceiptGood
{
  
    public class DeleteStoreReceiptGoodCommandValidator : AbstractValidator<DeleteStoreReceiptGoodCommand>
    {
        public DeleteStoreReceiptGoodCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
