using System;
using System.Collections.Generic;

namespace TDM.Application.Doc.StoreReceipts.Commands.SendIpasStoreAllocation
{
    public class SendIpasStoreAllocationRequest
    {
        public Guid StoreReceiptId { get; set; }
        public string TerminalCode { get; set; }
        public List<SendIpasStoreAllocationGoodRequest> Goods { get; set; } = new();
        public List<SendIpasStoreAllocationContainerRequest> Containers { get; set; } = new();
    }
    public class SendIpasStoreAllocationGoodRequest
    {
        public string CargoType { get; set; }
        public DateTime OperationDate { get; set; }
        public string StorageAreaCode { get; set; }
        public string HsCode { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string PackageTypeCode { get; set; }
        public decimal PackageQuantity { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public decimal Volume { get; set; }
        public bool IsNonPalletized { get; set; }
        public bool IsDamaged { get; set; }
        public bool IsDangerous { get; set; }
        public bool IsVoluminous { get; set; }
        public bool? IsHeavy { get; set; }
    }
    public class SendIpasStoreAllocationContainerRequest
    {
        public DateTime OperationDate { get; set; }
        public string StorageAreaCode { get; set; }
        public string ContainerNo { get; set; }
        public int Quantity { get; set; }
    }
}
