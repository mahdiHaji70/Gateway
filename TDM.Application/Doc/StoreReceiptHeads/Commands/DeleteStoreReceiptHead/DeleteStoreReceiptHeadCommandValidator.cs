using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.StoreReceipt.Command.DeleteStoreReceipt
{
    public class DeleteStoreReceiptHeadCommandValidator : AbstractValidator<DeleteStoreReceiptHeadCommand>
    {
        public DeleteStoreReceiptHeadCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
