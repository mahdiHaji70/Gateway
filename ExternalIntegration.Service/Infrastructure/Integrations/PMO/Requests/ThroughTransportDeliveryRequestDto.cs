namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class ThroughTransportDeliveryRequestDto
    {
        public string TerminalCode { get; set; } = null!;
        public DateTime Date { get; set; }
        public string VoyageNoticeNo { get; set; } = null!;
        public string ThroughTransportsNo { get; set; } = null!;
        public Guid BillOfLadingId { get; set; }
        public string CarrierIdNumber { get; set; } = null!;
        public int CarrierType { get; set; }
        public string? Remark { get; set; }
        public List<GeneralCargoThroughTransportDeliveryRequestDto> GeneralCargoList { get; set; } = [];
        public List<BulkThroughTransportDeliveryRequestDto> BulkList { get; set; } = [];
        public List<string> ContainerList { get; set; } = [];
    }
}
