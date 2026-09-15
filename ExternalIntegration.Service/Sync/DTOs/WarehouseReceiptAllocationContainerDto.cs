namespace ExternalIntegration.Service.Sync.DTOs
{
    public class WarehouseReceiptAllocationContainerDto
    {
        public DateTime OperationDate { get; set; }
        public string StorageAreaCode { get; set; } = string.Empty;
        public string ContainerNo { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
