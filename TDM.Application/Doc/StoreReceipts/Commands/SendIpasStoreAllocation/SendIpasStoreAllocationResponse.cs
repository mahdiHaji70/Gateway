using System;
namespace TDM.Application.Doc.StoreReceipts.Commands.SendIpasStoreAllocation
{
    public class SendIpasStoreAllocationResponse
    {
        public Guid StoreReceiptId { get; set; }
        public bool IsSent { get; set; }
        public string ErrorMessage { get; set; }
    }
}
