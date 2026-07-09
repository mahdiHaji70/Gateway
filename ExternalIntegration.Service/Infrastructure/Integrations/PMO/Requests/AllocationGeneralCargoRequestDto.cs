using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class AllocationGeneralCargoRequestDto
    {
        public DateTime OperationDate { get; set; }
        public string StorageAreaCode { get; set; }
        public StoreReceiptAllocationGeneralCargoRequestDto GeneralCargo { get; set; }
    }
}