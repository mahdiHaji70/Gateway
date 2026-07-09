namespace ExternalIntegration.Service.Sync.DTOs
{
    public class StoreReceiptContainerGoodDto
    {
        public string HSCode { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public decimal PackageQuantity { get; set; }
        public string PackageTypeCode { get; set; }
    }
}