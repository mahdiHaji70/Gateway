namespace ExternalIntegration.Service.Sync.DTOs
{
    public class ThroughTransportBulkDto
    {
        public string HsCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
    }
}
