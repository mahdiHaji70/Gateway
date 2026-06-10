namespace TDM.Infrastructure.Integrations.Responses
{
    public class ContainerResponseDto
    {
        public string? ContainerNo { get; set; }
        public string? ContainerTypeAndSize { get; set; }
        public string? ContainerTypeAndSizeCode { get; set; }
        public List<ContainerGoodResponseDto>? Goods { get; set; }
    }
}