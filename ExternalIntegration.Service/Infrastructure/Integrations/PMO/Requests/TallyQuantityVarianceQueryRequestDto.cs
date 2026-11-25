namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests
{
    public class TallyQuantityVarianceQueryRequestDto
    {
        public string TerminalCode { get; set; } = string.Empty;
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
