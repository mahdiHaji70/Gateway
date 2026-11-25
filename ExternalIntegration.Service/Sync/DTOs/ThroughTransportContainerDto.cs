namespace ExternalIntegration.Service.Sync.DTOs
{
    public class ThroughTransportContainerDto
    {
        public string ContainerNo { get; set; } = string.Empty;
        public string ContainerTypeAndSize { get; set; } = string.Empty;
        public string ContainerTypeAndSizeCode { get; set; } = string.Empty;
        public List<ThroughTransportGoodDto> Goods { get; set; } = [];
    }
}
