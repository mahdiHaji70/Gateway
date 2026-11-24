namespace TDM.Infrastructure.Integrations.Responses
{
    public class VoyageSyncResponseDto
    {
        public Guid Id { get; set; }
        public string VoyageNo { get; set; } = null!;
        public string NoticeNo { get; set; } = null!;
        public DateTime NoticeDate { get; set; }
        public DateTime? Eta { get; set; }
        public DateTime? Etd { get; set; }
        public string ShippingLine { get; set; } = null!;
        public string ShippingAgent { get; set; } = null!;
        public VoyageSyncVesselDataDto? VesselData { get; set; }
    }

    public class VoyageSyncVesselDataDto
    {
        public string Name { get; set; } = null!;
        public string Imo { get; set; } = null!;
    }
}
