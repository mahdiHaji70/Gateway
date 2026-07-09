using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class StoreReceiptContainerResponseDto
    {
        public string ContainerNo { get; set; }
        public string ContainerTypeAndSizeCode { get; set; }
        public string containerTypeAndSize { get; set; }
        public string SealNumber { get; set; }
        public string Remark { get; set; }
        public Guid? billOfLadingId { get; set; }
        public List<StoreReceiptContainerGoodResponseDto> Goods { get; set; }
        public DangerousSpecificationResponseDto DangerousSpecification { get; set; }
    }
}