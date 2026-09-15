namespace ExternalIntegration.Service.Sync.DTOs
{
    public class WarehouseReceiptAllocationBulkDto
    {
        public DateTime OperationDate { get; set; }
        public string StorageAreaCode { get; set; } = string.Empty;
        public WarehouseReceiptAllocationBulkDetailsDto Bulk { get; set; } = new();
    }

    public class WarehouseReceiptAllocationBulkDetailsDto
    {
        public string HsCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public bool IsDangerous { get; set; }
    }
}
