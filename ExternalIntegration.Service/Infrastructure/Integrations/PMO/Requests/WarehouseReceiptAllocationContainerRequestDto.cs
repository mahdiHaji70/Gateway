namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class WarehouseReceiptAllocationContainerRequestDto
    {
        public DateTime OperationDate { get; set; }
        public DateTime FirstTerminalDischargeDate { get; set; }
        public DateTime FirstPortDischargeDate { get; set; }
        public string StorageAreaCode { get; set; } = string.Empty;
        public string ContainerNo { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
