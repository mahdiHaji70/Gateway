namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class ThroughTransportGoodResponseDto
    {
        public string HsCode { get; set; } = string.Empty;
        public string PackageTypeCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal PackageQuantity { get; set; }
        public decimal Weight { get; set; }
    }
}
