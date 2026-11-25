namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class TallyQuantityVarianceBulkResponseDto
    {
        public Guid Id { get; set; }
        public string HsCode { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Weight { get; set; }
        public bool IsDangerous { get; set; }
        public int VarianceTypeCode { get; set; }
        public string VarianceTypeName { get; set; } = string.Empty;
        public decimal BillOfLadingAmount { get; set; }
        public decimal DischargeAmount { get; set; }
        public decimal OverageAmount { get; set; }
        public decimal ShortageAmount { get; set; }
    }
}
