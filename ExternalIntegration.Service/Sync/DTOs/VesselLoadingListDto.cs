namespace ExternalIntegration.Service.Sync.DTOs
{
    public class VesselLoadingListDto
    {
        public Guid Id { get; set; }
        public string Port { get; set; }
        public string PortCode { get; set; }
        public DateTime CreationDate { get; set; }
        public string State { get; set; }
        public string Remark { get; set; }
        public VesselLoadingListVoyageDto Voyage { get; set; }
        public List<VesselLoadingListPermitDto> Permits { get; set; }
    }
}
