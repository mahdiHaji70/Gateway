namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class GeneralCargoDeliveryReturnRequestDto
    {
        public string HsCode { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public string PackageTypeCode { get; set; } = null!;
        public decimal PackageQuantity { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public bool IsNonPalletized { get; set; }
        public bool IsDamaged { get; set; }
        public bool IsDangerous { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public decimal? Length { get; set; }
        public bool IsVoluminous { get; set; }
        public bool IsHeavy { get; set; }
        public bool NoBrandName { get; set; }
        public bool DangerousNotNoticed { get; set; }
        public string? Remark { get; set; }
        public DangerousSpecificationDeliveryReturnRequestDto DangerousSpecification { get; set; } = new();
    }
}
