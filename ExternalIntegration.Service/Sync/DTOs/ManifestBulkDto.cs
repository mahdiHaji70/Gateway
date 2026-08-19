namespace ExternalIntegration.Service.Sync.DTOs
{
    public class ManifestBulkDto
    {
        public string HSCode { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public decimal? Volume { get; set; }
    }
}
