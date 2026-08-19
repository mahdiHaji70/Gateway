namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class ManifestItemResponseDto
    {
        public Guid Id { get; set; }
        public string VersionNumber { get; set; }
        public string No { get; set; }
        public string LocalNo { get; set; }
        public string TraceCode { get; set; }
        public Guid ManifestId { get; set; }
        public string ManifestNo { get; set; }
        public string VesselNationality { get; set; }
        public string TransportationMode { get; set; }
        public string CustomsProcedure { get; set; }
        public string CustomsProcedureCode { get; set; }
        public string Consignee { get; set; }
        public string ConsigneeIdNumber { get; set; }
        public string Consigor { get; set; }
        public string NotifyParty { get; set; }
        public decimal PackageQuantity { get; set; }
        public string Remark { get; set; }
        public Guid ShippingLineId { get; set; }
        public string ShippingLine { get; set; }
        public string ShippingAgentIdNumber { get; set; }
        public string ShippingAgent { get; set; }
        public string LoadingPlace { get; set; }
        public string LoadingPlaceCode { get; set; }
        public ManifestCompanyResponseDto ShippingOrForwarderCompany { get; set; }
        public List<ManifestContainerResponseDto> ContainersList { get; set; }
        public List<ManifestGeneralCargoResponseDto> GeneralCargoList { get; set; }
        public List<ManifestBulkResponseDto> BulkList { get; set; }
        public int Type { get; set; }
        public string TypeName { get; set; }
    }
}
