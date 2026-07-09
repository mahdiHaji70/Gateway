namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class StoreReceiptAllocationBulkRequestDto
    {
        public string HSCode { get; set; }
        public string Description { get; set; }
        public Decimal Weight { get; set; }
        public Decimal Volume { get; set; }
        public bool IsDangerous { get; set; }
    }
}