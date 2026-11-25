namespace ExternalIntegration.Service.Sync.DTOs
{
    public class TallyQuantityVarianceGeneralCargoDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string HsCode { get; set; } = string.Empty;
        public string PackageTypeCode { get; set; } = string.Empty;
        public string PackageType { get; set; } = string.Empty;
        public decimal PackageQuantity { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public bool IsNonPalletized { get; set; }
        public bool IsDamaged { get; set; }
        public bool IsDangerous { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public bool IsVoluminous { get; set; }
        public int VarianceTypeCode { get; set; }
        public string VarianceTypeName { get; set; } = string.Empty;
        public decimal BillOfLadingAmount { get; set; }
        public decimal DischargeAmount { get; set; }
        public decimal OverageAmount { get; set; }
        public decimal ShortageAmount { get; set; }
    }
}
