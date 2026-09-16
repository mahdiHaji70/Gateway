using MediatR;
using System;
namespace TDM.Application.Doc.StoreReceipts.Commands.SendIpasStoreAllocation
{
    public record SendIpasStoreAllocationCommand(Guid StoreReceiptId) : IRequest<SendIpasStoreAllocationResponse>;
}
