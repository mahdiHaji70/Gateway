namespace ExternalIntegration.Service.Sync.DTOs
{
    public class SendStoreReceiptAllocationDto
    {
         public Guid WarehouseReceiptId { get; set; }
        public string TerminalCode { get; set; }
        public List<AllocationGeneralCargoDto> GeneralCargoList { get; set; }
        public List<AllocationBulkDto> BulkList { get; set; }
        public List<AllocationContainerDto> ContainerList { get; set; }
    }
}
