namespace ExternalIntegration.Service.Sync.DTOs
{
    public class VesselLoadingListContainerDto
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
        public VesselLoadingListContainerGoodDto Good { get; set; }
    }
}
