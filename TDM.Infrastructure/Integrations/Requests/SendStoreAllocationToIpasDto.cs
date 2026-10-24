namespace TDM.Infrastructure.Integrations.Requests
{
    public class SendStoreAllocationToIpasDto
    {
        public Guid WarehouseReceiptId { get; set; }
        public string TerminalCode { get; set; }
        public List<StoreAllocationGeneralCargoDto> GeneralCargoList { get; set; }
        public List<StoreAllocationBulkDto> BulkList { get; set; }
        public List<StoreAllocationContainerDto> ContainerList { get; set; }
    }

    public class StoreAllocationGeneralCargoDto
    {
        public DateTime OperationDate { get; set; }
        public string StorageAreaCode { get; set; }
        public StoreAllocationGeneralCargoGoodDto GeneralCargo { get; set; }
    }

    public class StoreAllocationGeneralCargoGoodDto
    {
        public string HsCode { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string PackageTypeCode { get; set; }
        public decimal PackageQuantity { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public bool IsNonPalletized { get; set; }
        public bool IsDamaged { get; set; }
        public bool IsDangerous { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public bool IsVoluminous { get; set; }
        public bool? IsHeavy { get; set; }
    }

    public class StoreAllocationBulkDto
    {
        public DateTime OperationDate { get; set; }
        public string StorageAreaCode { get; set; }
        public StoreAllocationBulkGoodDto Bulk { get; set; }
    }

    public class StoreAllocationBulkGoodDto
    {
        public string HsCode { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public bool IsDangerous { get; set; }
    }

    public class StoreAllocationContainerDto
    {
        public DateTime OperationDate { get; set; }
        public string StorageAreaCode { get; set; }
        public string ContainerNo { get; set; }
        public int Quantity { get; set; }
    }
}
