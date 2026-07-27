using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.StoreReceipt.Command.DeleteStoreReceipt
{
   
    public class DeleteStoreReceiptCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteStoreReceiptCommand(Guid id)
        {
            Id = id;
        }
    }
}
