namespace ExternalIntegration.Service.Domain.Entities
{
    public class StoreReceiptManifestItem
    {
        public Guid StoreReceiptId { get; set; }
        public Guid BillOfLadingId { get; set; }
        public StoreReceipt StoreReceipt { get; set; } = null!;
    }
}
