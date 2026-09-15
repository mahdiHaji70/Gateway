using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.StoreReceiptContainers.Commands.DeleteStoreReceiptContainer
{
    public class DeleteStoreReceiptContainerCommandValidator : AbstractValidator<DeleteStoreReceiptContainerCommand>
    {
        public DeleteStoreReceiptContainerCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
