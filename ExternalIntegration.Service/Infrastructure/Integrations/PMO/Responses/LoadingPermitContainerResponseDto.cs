namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class LoadingPermitContainerResponseDto
    {
        public string ContainerNo { get; set; } 
        public string ContainerTypeAndSizeCode { get; set; }
        public string SealNumber { get; set; } 
        public string Remark { get; set; }
        public LoadingPermitContainerGoodResponseDto Good { get; set; }
        public LoadingPermitDangerousSpecificationResponseDto DangerousSpecification { get; set; }
    }
}
