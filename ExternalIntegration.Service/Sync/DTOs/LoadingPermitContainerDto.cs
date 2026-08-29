namespace ExternalIntegration.Service.Sync.DTOs
{
    public class LoadingPermitContainerDto
    {
        public string ContainerNo { get; set; } 
        public string ContainerTypeAndSizeCode { get; set; }
        public string SealNumber { get; set; } 
        public string Remark { get; set; }
        public LoadingPermitContainerGoodDto Good { get; set; }
        public LoadingPermitDangerousSpecificationDto DangerousSpecification { get; set; }
    }
}
