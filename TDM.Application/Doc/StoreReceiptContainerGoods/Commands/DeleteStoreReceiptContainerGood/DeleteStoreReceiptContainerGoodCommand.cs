using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.StoreReceiptContainerContainerGoods.Commands.DeleteStoreReceiptContainerContainerGood
{
   
    public class DeleteStoreReceiptContainerGoodCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteStoreReceiptContainerGoodCommand(Guid id)
        {
            Id = id;
        }
    }
}
