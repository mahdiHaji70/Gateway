namespace ExternalIntegration.Service.Sync.DTOs
{
    public class ContainerResultDto
    {
        public string? ContainerNo { get; set; }
        public string? ContainerTypeAndSize { get; set; }
        public string? ContainerTypeAndSizeCode { get; set; }
        public List<ContainerGoodResultDto>? Goods { get; set; }
    }
}
