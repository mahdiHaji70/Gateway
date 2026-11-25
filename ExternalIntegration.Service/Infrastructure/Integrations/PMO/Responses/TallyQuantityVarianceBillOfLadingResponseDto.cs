namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class TallyQuantityVarianceBillOfLadingResponseDto
    {
        public Guid Id { get; set; }
        public Guid TallyQuantityVarianceId { get; set; }
        public string ShippingLineId { get; set; } = string.Empty;
        public string ShippingLine { get; set; } = string.Empty;
        public string ShippingAgentIdNumber { get; set; } = string.Empty;
        public string ShippingAgent { get; set; } = string.Empty;
        public Guid CargoManifestId { get; set; }
        public string No { get; set; } = string.Empty;
        public string Consignee { get; set; } = string.Empty;
        public string Consignor { get; set; } = string.Empty;
        public decimal PackageQuantity { get; set; }
        public decimal Overage { get; set; }
        public decimal Shortage { get; set; }
        public List<TallyQuantityVarianceContainerResponseDto> ContainerList { get; set; } = [];
        public List<TallyQuantityVarianceGeneralCargoResponseDto> GeneralCargoList { get; set; } = [];
        public List<TallyQuantityVarianceBulkResponseDto> BulkList { get; set; } = [];
    }
}
