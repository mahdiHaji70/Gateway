namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class ContainerResponseDto
    {
        public string? ContainerNo { get; set; }
        public string? ContainerTypeAndSize { get; set; }
        public string? ContainerTypeAndSizeCode { get; set; }
        public List<ContainersGoodResponseDto>? Goods { get; set; }
    }
}
