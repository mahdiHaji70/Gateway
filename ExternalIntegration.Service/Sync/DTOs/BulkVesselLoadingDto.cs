namespace ExternalIntegration.Service.Sync.DTOs
{
    public class BulkVesselLoadingDto
    {
        public string HsCode { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Weight { get; set; }
        public decimal? Volume { get; set; }
        public bool IsDangerous { get; set; }
        public string? Remark { get; set; }
    }
}
