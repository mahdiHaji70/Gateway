namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class ContainerResultDto
    {
        public string? ContainerNo { get; set; }
        public string? ContainerTypeAndSize { get; set; }
        public string? ContainerTypeAndSizeCode { get; set; }
        public List<ContainersGoodDto>? Goods { get; set; }
    }
}
