namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class ThroughTransportBulkResponseDto
    {
        public string HsCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
    }
}
