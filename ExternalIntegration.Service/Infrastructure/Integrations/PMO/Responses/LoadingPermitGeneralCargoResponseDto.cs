namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class LoadingPermitGeneralCargoResponseDto
    {
        public string HSCode { get; set; } 
        public string Description { get; set; } 
        public string BrandName { get; set; } 
        public string PackageTypeCode { get; set; } 
        public string PackageType { get; set; } 
        public string Remark { get; set; } 
        public decimal PackageQuantity { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public bool IsNonPalletized { get; set; }
        public bool IsDamaged { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public bool IsVoluminous { get; set; }
        public bool IsHeavy { get; set; }
        public bool NoBrandName { get; set; }
        public bool IsDangerous { get; set; }
        public bool DangerousNotNoticed { get; set; }
        public LoadingPermitDangerousSpecificationResponseDto DangerousSpecification { get; set; }
    }
}
