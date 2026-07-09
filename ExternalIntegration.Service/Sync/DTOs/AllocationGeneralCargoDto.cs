namespace ExternalIntegration.Service.Sync.DTOs
{
    public class AllocationGeneralCargoDto
    {
        public DateTime OperationDate { get; set; }
        public string StorageAreaCode { get; set; }
        public StoreReceiptGeneralCargoDto GeneralCargo { get; set; }
    }
}