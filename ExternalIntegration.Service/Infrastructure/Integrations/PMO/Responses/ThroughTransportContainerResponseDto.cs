namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class ThroughTransportContainerResponseDto
    {
        public string ContainerNo { get; set; } = string.Empty;
        public string ContainerTypeAndSize { get; set; } = string.Empty;
        public string ContainerTypeAndSizeCode { get; set; } = string.Empty;
        public List<ThroughTransportGoodResponseDto> Goods { get; set; } = [];
    }
}
