using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class SendStoreReceiptAllocationRequestDto
    {
        public Guid WarehouseReceiptId { get; set; }
        public string TerminalCode { get; set; }
        public List<AllocationGeneralCargoRequestDto> GeneralCargoList { get; set; }
        public List<AllocationBulkRequestDto> BulkList { get; set; }
        public List<AllocationContainerRequestDto> ContainerList { get; set; }
    }
}
