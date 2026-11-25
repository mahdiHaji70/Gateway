namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class ThroughTransportResponseDto
    {
        public Guid Id { get; set; }
        public string No { get; set; } = string.Empty;
        public int TypeId { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Port { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string CustomsProcedureCode { get; set; } = string.Empty;
        public string CustomsProcedure { get; set; } = string.Empty;
        public string CountryOrigin { get; set; } = string.Empty;
        public string CountryOriginCode { get; set; } = string.Empty;
        public string CityOrigin { get; set; } = string.Empty;
        public string CityOriginCode { get; set; } = string.Empty;
        public string CountryDestinationCode { get; set; } = string.Empty;
        public string CountryDestination { get; set; } = string.Empty;
        public string CargoOwnerName { get; set; } = string.Empty;
        public string CargoOwnerIdNumber { get; set; } = string.Empty;
        public int CargoOwnerType { get; set; }
        public string CargoOwnerTypeName { get; set; } = string.Empty;
        public string CargoOwnerRepName { get; set; } = string.Empty;
        public string CargoOwnerRepIdNumber { get; set; } = string.Empty;
        public int CargoOwnerRepType { get; set; }
        public string CargoOwnerRepTypeName { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string VoyageNoticeNo { get; set; } = string.Empty;
        public string ArrivalVoyageNo { get; set; } = string.Empty;
        public string VoyageShippingAgentIdNumber { get; set; } = string.Empty;
        public List<ThroughTransportBulkResponseDto> BulkList { get; set; } = [];
        public List<ThroughTransportCargoResponseDto> CargoList { get; set; } = [];
        public List<ThroughTransportContainerResponseDto> ContainerList { get; set; } = [];
    }
}
