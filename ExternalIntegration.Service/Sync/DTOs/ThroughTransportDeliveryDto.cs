namespace ExternalIntegration.Service.Sync.DTOs
{
    public class ThroughTransportDeliveryDto
    {
        public string TerminalCode { get; set; } = null!;
        public DateTime Date { get; set; }
        public string VoyageNoticeNo { get; set; } = null!;
        public string ThroughTransportsNo { get; set; } = null!;
        public Guid BillOfLadingId { get; set; }
        public string CarrierIdNumber { get; set; } = null!;
        public int CarrierType { get; set; }
        public string? Remark { get; set; }
        public List<GeneralCargoThroughTransportDeliveryDto> GeneralCargoList { get; set; } = [];
        public List<BulkThroughTransportDeliveryDto> BulkList { get; set; } = [];
        public List<string> ContainerList { get; set; } = [];
    }
}
