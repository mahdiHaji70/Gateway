
namespace ExternalIntegration.Service.Sync.DTOs
{
    public class ContainerVesselDischargeDto
    {
        public string ContainerNo { get; set; } = null!;
        public string ContainerTypeAndSizeCode { get; set; } = null!;
        public string SealNumber { get; set; } = null!;
        public string? Remark { get; set; }
        public bool IsDangerous { get; set; }
        public bool DangerousNotNoticed { get; set; }

        public DangerousSpecificationVesselDischargeDto DangerousSpecification { get; set; } = new();
        public VesselDischargeSpecificationDto DischargeSpecification { get; set; } = new();

    }
}
