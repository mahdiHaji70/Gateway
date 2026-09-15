namespace ExternalIntegration.Service.Sync.DTOs
{
    public class WarehouseReceiptAllocationGeneralCargoDto
    {
        public DateTime OperationDate { get; set; }
        public string StorageAreaCode { get; set; } = string.Empty;
        public WarehouseReceiptAllocationCargoDetailsDto GeneralCargo { get; set; } = new();
    }

    public class WarehouseReceiptAllocationCargoDetailsDto
    {
        public string HsCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string BrandName { get; set; } = string.Empty;
        public string PackageTypeCode { get; set; } = string.Empty;
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
}
