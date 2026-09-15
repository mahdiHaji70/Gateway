namespace ExternalIntegration.Service.Sync.DTOs
{
    /// <summary>
    /// Request for the PMO ipas-WReceiptsAllocation service.
    /// This model is intentionally separate from SendStoreReceiptAllocationDto.
    /// </summary>
    public class WarehouseReceiptAllocationDto
    {
        public Guid WarehouseReceiptId { get; set; }
        public string TerminalCode { get; set; } = string.Empty;
        public List<WarehouseReceiptAllocationGeneralCargoDto> GeneralCargoList { get; set; } = new();
        public List<WarehouseReceiptAllocationBulkDto> BulkList { get; set; } = new();
        public List<WarehouseReceiptAllocationContainerDto> ContainerList { get; set; } = new();
    }
}
