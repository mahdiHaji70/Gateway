using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.StoreReceiptContainers.Commands.DeleteStoreReceiptContainer
{
    public class DeleteStoreReceiptContainerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteStoreReceiptContainerCommand(Guid id)
        {
            Id = id;
        }
    }
}
