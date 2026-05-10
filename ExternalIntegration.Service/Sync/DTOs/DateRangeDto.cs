namespace ExternalIntegration.Service.Sync.DTOs
{
    public class DateRangeDto
    {
        public required string TerminalCode { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public required string PortCode { get; set; }
    }
}
