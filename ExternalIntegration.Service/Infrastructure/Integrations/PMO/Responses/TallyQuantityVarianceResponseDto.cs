namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class TallyQuantityVarianceResponseDto
    {
        public Guid Id { get; set; }
        public Guid VoyageId { get; set; }
        public string VoyageNoticeNo { get; set; } = string.Empty;
        public string Berth { get; set; } = string.Empty;
        public string Vessel { get; set; } = string.Empty;
        public string VoyageShippingLineId { get; set; } = string.Empty;
        public string VoyageShippingLine { get; set; } = string.Empty;
        public string ShippingAgent { get; set; } = string.Empty;
        public string ShippingAgentIdNumber { get; set; } = string.Empty;
        public bool IsApprovedByAgent { get; set; }
        public bool IsApprovedByOperator { get; set; }
        public List<TallyQuantityVarianceBillOfLadingResponseDto> BillOfLadings { get; set; } = [];
        public List<TallyQuantityVarianceApproverResponseDto> Approvers { get; set; } = [];
    }
}
