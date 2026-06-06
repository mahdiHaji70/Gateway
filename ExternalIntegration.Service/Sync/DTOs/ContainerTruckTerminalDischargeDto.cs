namespace ExternalIntegration.Service.Sync.DTOs
{
    public class ContainerTruckTerminalDischargeDto
    {
        public string ContainerNo { get; set; }
        public string ContainerTypeAndSizeCode { get; set; }
        public string SealNumber { get; set; }
        public string Remark { get; set; }
        public DangerousSpecificationDto DangerousSpecification { get; set; }
    }
}
