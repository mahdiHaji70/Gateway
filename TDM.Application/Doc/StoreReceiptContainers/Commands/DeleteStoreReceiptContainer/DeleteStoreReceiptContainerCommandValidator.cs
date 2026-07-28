using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Declarations.Commands.RemoveDeclaration;

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
