using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDM.Application.Doc.StoreReceiptGoods.Commands.DeleteStoreReceiptGood
{
 
    public class DeleteStoreReceiptGoodCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteStoreReceiptGoodCommand(Guid id)
        {
            Id = id;
        }
    }
}
