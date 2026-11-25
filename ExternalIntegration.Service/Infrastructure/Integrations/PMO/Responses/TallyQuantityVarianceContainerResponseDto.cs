namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class TallyQuantityVarianceContainerResponseDto
    {
        public string No { get; set; } = string.Empty;
        public string ISOCode { get; set; } = string.Empty;
        public string SealNumber { get; set; } = string.Empty;
        public int VarianceTypeCode { get; set; }
        public string VarianceTypeName { get; set; } = string.Empty;
        public decimal BillOfLadingAmount { get; set; }
        public decimal DischargeAmount { get; set; }
        public decimal OverageAmount { get; set; }
        public decimal ShortageAmount { get; set; }
    }
}
