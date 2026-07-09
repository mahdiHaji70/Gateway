namespace ExternalIntegration.Service.Sync.DTOs
{
    public class StoreReceiptContainerDto
    {
        public string ContainerNo { get; set; }
        public string ContainerTypeAndSizeCode { get; set; }
        public string containerTypeAndSize { get; set; }
        public string SealNumber { get; set; }
        public string Remark { get; set; }
        public Guid? billOfLadingId { get; set; }
        public List<StoreReceiptContainerGoodDto> Goods { get; set; }
        public DangerousSpecificationDto DangerousSpecification { get; set; }

    }
}
