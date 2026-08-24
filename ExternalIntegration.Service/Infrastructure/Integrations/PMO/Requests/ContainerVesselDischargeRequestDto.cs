namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class ContainerVesselDischargeRequestDto
    {
        public string ContainerNo { get; set; } = null!;
        public string ContainerTypeAndSizeCode { get; set; } = null!;
        public string SealNumber { get; set; } = null!;
        public string? Remark { get; set; }
        public bool IsDangerous { get; set; }
        public bool DangerousNotNoticed { get; set; }

        public DangerousSpecificationVesselDischargeRequestDto DangerousSpecification { get; set; } = new();
        public VesselDischargeSpecificationRequestDto DischargeSpecification { get; set; } = new();
    }
}
