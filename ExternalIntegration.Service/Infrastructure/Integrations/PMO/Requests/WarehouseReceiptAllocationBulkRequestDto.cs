namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class WarehouseReceiptAllocationBulkRequestDto
    {
        public DateTime OperationDate { get; set; }
        public string StorageAreaCode { get; set; } = string.Empty;
        public WarehouseReceiptAllocationBulkDetailsRequestDto Bulk { get; set; } = new();
    }

    public class WarehouseReceiptAllocationBulkDetailsRequestDto
    {
        public string HsCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Weight { get; set; }
        public decimal Volume { get; set; }
        public bool IsDangerous { get; set; }
    }
}
