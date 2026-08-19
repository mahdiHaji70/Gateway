namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class ManifestContainerGoodResponseDto
    {
        public string HSCode { get; set; }
        public string GoodsDescription { get; set; }
        public string PackageType { get; set; }
        public string PackageTypeCode { get; set; }
        public decimal packageCount { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal? NetWeight { get; set; }
    }
}
