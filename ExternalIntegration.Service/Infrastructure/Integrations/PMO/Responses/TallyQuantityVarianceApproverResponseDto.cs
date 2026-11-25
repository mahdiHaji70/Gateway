namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class TallyQuantityVarianceApproverResponseDto
    {
        public Guid Id { get; set; }
        public Guid TallyQuantityVarianceId { get; set; }
        public string ShippingAgent { get; set; } = string.Empty;
        public string ShippingAgentIdNumber { get; set; } = string.Empty;
        public string Terminal { get; set; } = string.Empty;
        public string ApproveBy { get; set; } = string.Empty;
        public DateTime ApproveDate { get; set; }
    }
}
