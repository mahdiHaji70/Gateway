namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class ContainerVesselLoadingRequestDto
    {
        public string ContainerNo { get; set; } = null!;
        public string? Remark { get; set; }
        public VesselLoadingDischargeSpecificationRequestDto DischargeSpecification { get; set; } = new();
    }
}
