
namespace ExternalIntegration.Service.Sync.DTOs
{
    public class BulkVesselDischargeDto
    {
        public string HsCode { get; set; } = null!;
        public string Description { get; set; } = null!;
        public float Weight { get; set; }
        public float Volume { get; set; }
        public bool IsDangerous { get; set; }
        public bool DangerousNotNoticed { get; set; }
        public string? Remark { get; set; }
        public DangerousSpecificationVesselDischargeDto DangerousSpecification { get; set; } = new();

    }
}
