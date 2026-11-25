namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class DeliveryReturnRequestDto
    {
        public string TerminalCode { get; set; } = string.Empty;
        public Guid TransactionId { get; set; }
        public decimal? TransactionNo { get; set; }
        public DateTime Date { get; set; }
        public string? Remark { get; set; }
        public List<GeneralCargoDeliveryReturnRequestDto> GeneralCargoList { get; set; } = [];
        public List<BulkDeliveryReturnRequestDto> BulkList { get; set; } = [];
        public List<string> ContainerList { get; set; } = [];
    }
}
