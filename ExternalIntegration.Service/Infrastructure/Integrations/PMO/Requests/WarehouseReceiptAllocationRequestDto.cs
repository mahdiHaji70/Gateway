namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class WarehouseReceiptAllocationRequestDto
    {
        public Guid WarehouseReceiptId { get; set; }
        public string TerminalCode { get; set; } = string.Empty;
        public List<WarehouseReceiptAllocationGeneralCargoRequestDto> GeneralCargoList { get; set; } = new();
        public List<WarehouseReceiptAllocationBulkRequestDto> BulkList { get; set; } = new();
        public List<WarehouseReceiptAllocationContainerRequestDto> ContainerList { get; set; } = new();
    }
}
