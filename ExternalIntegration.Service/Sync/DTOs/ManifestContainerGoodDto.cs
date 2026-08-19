namespace ExternalIntegration.Service.Sync.DTOs
{
    public class ManifestContainerGoodDto
    {
        public string HSCode { get; set; }
        public string GoodsDescription { get; set; }
        public string PackageType { get; set; }
        public string PackageTypeCode { get; set; }
        public decimal PackageCount { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal? NetWeight { get; set; }
    }
}
