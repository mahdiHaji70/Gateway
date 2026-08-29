namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class VesselLoadingPermitContainerResponseDto
    {
        public string ContainerNo { get; set; }
        public string ContainerTypeAndSizeCode { get; set; }
        public string SealNumber { get; set; }
        public string Remark { get; set; }
        public VesselLoadingPermitContainerGoodResponseDto Good { get; set; }
        public VesselLoadingPermitDangerousSpecificationResponseDto DangerousSpecification { get; set; }
    }
}
