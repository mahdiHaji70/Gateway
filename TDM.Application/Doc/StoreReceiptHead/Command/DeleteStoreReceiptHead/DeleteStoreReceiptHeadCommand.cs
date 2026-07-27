using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.StoreReceipt.Command.DeleteStoreReceipt
{
   
    public class DeleteStoreReceiptHeadCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteStoreReceiptHeadCommand(Guid id)
        {
            Id = id;
        }
    }
}
