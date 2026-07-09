namespace ExternalIntegration.Service.Sync.DTOs
{
    public class StoreReceiptAllocationGeneralCargoDto
    {
        public string HsCode { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string PackageTypeCode { get; set; }
        public Decimal PackageQuantity { get; set; }
        public Decimal GrossWeight { get; set; }
        public Decimal NetWeight { get; set; }
        public bool IsNonPalletized { get; set; }
        public bool IsDamaged { get; set; }
        public bool IsDangerous { get; set; }
        public Decimal Width { get; set; }
        public Decimal Height { get; set; }
        public Decimal Length { get; set; }
        public bool IsVoluminous { get; set; }
        public bool IsHeavy { get; set; }
    }
}