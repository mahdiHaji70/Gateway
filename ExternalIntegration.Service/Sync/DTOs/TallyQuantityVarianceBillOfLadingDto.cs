namespace ExternalIntegration.Service.Sync.DTOs
{
    public class TallyQuantityVarianceBillOfLadingDto
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
        public List<TallyQuantityVarianceContainerDto> ContainerList { get; set; } = [];
        public List<TallyQuantityVarianceGeneralCargoDto> GeneralCargoList { get; set; } = [];
        public List<TallyQuantityVarianceBulkDto> BulkList { get; set; } = [];
    }
}
