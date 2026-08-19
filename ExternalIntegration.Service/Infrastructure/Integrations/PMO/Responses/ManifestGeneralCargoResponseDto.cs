namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class ManifestGeneralCargoResponseDto
    {
        public string HSCode { get; set; }
        public string Description { get; set; }
        public string PackageTypeCode { get; set; }
        public decimal PackageQuantity { get; set; }
        public string BrandName { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public bool? IsNonPalletized { get; set; }
        public bool? IsDangerous { get; set; }
        public decimal? ItemWidth { get; set; }
        public decimal? ItemHeight { get; set; }
        public decimal? ItemLength { get; set; }
        public bool? ItemIsVoluminous { get; set; }
    }
}
