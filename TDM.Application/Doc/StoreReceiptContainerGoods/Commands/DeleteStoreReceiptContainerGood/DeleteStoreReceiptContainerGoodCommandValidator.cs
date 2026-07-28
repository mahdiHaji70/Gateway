using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;


namespace TDM.Application.Doc.StoreReceiptContainerContainerGoods.Commands.DeleteStoreReceiptContainerContainerGood
{
    public class DeleteStoreReceiptContainerGoodCommandValidator : AbstractValidator<DeleteStoreReceiptContainerGoodCommand>
    {
        public DeleteStoreReceiptContainerGoodCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
