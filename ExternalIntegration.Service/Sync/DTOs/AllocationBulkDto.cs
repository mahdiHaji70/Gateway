namespace ExternalIntegration.Service.Sync.DTOs
{
    public class AllocationBulkDto
    {
        public DateTime OperationDate { get; set; }
        public string StorageAreaCode { get; set; }
        public StoreReceiptAllocationBulkDto Bulk { get; set; }
    }
}