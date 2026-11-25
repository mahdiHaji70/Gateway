namespace ExternalIntegration.Service.Sync.DTOs
{
    public class DeliveryReturnDto
    {
        public string TerminalCode { get; set; } = string.Empty;
        public Guid TransactionId { get; set; }
        public decimal? TransactionNo { get; set; }
        public DateTime Date { get; set; }
        public string? Remark { get; set; }
        public List<GeneralCargoDeliveryReturnDto> GeneralCargoList { get; set; } = [];
        public List<BulkDeliveryReturnDto> BulkList { get; set; } = [];
        public List<string> ContainerList { get; set; } = [];
    }
}
