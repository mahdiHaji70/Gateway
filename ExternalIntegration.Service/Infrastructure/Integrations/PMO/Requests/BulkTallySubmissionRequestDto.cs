namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class BulkTallySubmissionRequestDto
    {
        public string HsCode { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public bool IsDangerous { get; set; }
        public bool DangerousNotNoticed { get; set; }
        public string? Remark { get; set; }
        public DangerousSpecificationTallySubmissionRequestDto DangerousSpecification { get; set; } = new();
    }
}
