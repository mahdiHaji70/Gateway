namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class BulkVesselLoadingRequestDto
    {
        public string HsCode { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Weight { get; set; }
        public decimal? Volume { get; set; }
        public bool IsDangerous { get; set; }
        public string? Remark { get; set; }
    }
}
