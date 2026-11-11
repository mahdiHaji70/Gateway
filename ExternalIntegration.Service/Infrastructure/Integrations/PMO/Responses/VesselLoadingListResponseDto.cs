namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses
{
    public class VesselLoadingListResponseDto
    {
        public Guid Id { get; set; }
        public string Port { get; set; }
        public string PortCode { get; set; }
        public DateTime CreationDate { get; set; }
        public string State { get; set; }
        public string Remark { get; set; }
        public VesselLoadingListVoyageResponseDto Voyage { get; set; }
        public List<VesselLoadingListPermitResponseDto> Permits { get; set; }
    }
}
