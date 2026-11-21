namespace ExternalIntegration.Service.Sync.DTOs
{
    public class ContainerVesselLoadingDto
    {
        public string ContainerNo { get; set; } = null!;
        public string? Remark { get; set; }
        public VesselLoadingDischargeSpecificationDto DischargeSpecification { get; set; } = new();
    }
}
