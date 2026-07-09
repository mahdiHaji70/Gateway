using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class AllocationBulkRequestDto
    {
        public DateTime OperationDate { get; set; }
        public string StorageAreaCode { get; set; }
        public StoreReceiptAllocationBulkRequestDto Bulk { get; set; }
    }
}