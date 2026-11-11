namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class VesselLoadingListContainerResponseDto
    {
        public string ContainerNo { get; set; }
        public string ContainerTypeAndSizeCode { get; set; }
        public string SealNumber { get; set; }
        public string PortOfDischarge { get; set; }
        public string PortOfDestination { get; set; }
        public string MovementType { get; set; }
        public decimal NetWeight { get; set; }
        public decimal GrossWeight { get; set; }
        public string Remark { get; set; }
        public VesselLoadingListContainerGoodResponseDto Good { get; set; }
    }
}
