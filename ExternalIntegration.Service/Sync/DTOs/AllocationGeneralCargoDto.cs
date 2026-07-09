namespace ExternalIntegration.Service.Sync.DTOs
{
    public class AllocationGeneralCargoDto
    {
        public DateTime OperationDate { get; set; }
        public string StorageAreaCode { get; set; }
        public StoreReceiptAllocationGeneralCargoDto GeneralCargo { get; set; }
    }
}