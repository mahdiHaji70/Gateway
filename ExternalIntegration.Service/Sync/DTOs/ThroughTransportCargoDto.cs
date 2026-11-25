namespace ExternalIntegration.Service.Sync.DTOs
{
    public class ThroughTransportCargoDto
    {
        public string HsCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal GrossWeight { get; set; }
        public decimal NetWeight { get; set; }
        public string PackageType { get; set; } = string.Empty;
        public string PackageTypeCode { get; set; } = string.Empty;
        public decimal PackageQuantity { get; set; }
    }
}
