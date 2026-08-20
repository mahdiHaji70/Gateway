namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class ManifestChangeResponseDto
    {
        public Guid Id { get; set; }
        public decimal revisionNo { get; set; }
        public string Port { get; set; }
        public string portCode { get; set; }
        public DateTime Date { get; set; }
        public string Creator { get; set; }
        public string stateName { get; set; }
        public string manifestLocalNo { get; set; }
        public string voyageNoticeNo { get; set; }
        public Guid shippingLineId { get; set; }
        public string shippingLine { get; set; }
        public string shippingAgentIdNumber { get; set; }
        public string shippingAgent { get; set; }

        public List<ManifestChangeLogResponseDto> changeLogs { get; set; }
    }
}
