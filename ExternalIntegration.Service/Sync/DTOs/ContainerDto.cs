namespace ExternalIntegration.Service.Sync.DTOs
{
    public class ContainerDto
    {
        public string ContainerNo { get; set; }
        public string ContainerTypeAndSize { get; set; }
        public string ContainerTypeAndSizeCode { get; set; }
        public List<ContainerGoodDto> Goods { get; set; }
    }
}
