namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class BulkVesselDischargeRequestDto
    {
        public string HsCode { get; set; } = null!;
        public string Description { get; set; } = null!;
        public float Weight { get; set; }
        public float Volume { get; set; }
        public bool IsDangerous { get; set; }
        public bool DangerousNotNoticed { get; set; }
        public string? Remark { get; set; }
        public DangerousSpecificationVesselDischargeRequestDto DangerousSpecification { get; set; } = new();
    }
}
