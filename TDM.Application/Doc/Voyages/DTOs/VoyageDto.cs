namespace TDM.Application.Doc.Voyages.DTOs
{
    public class VoyageDto
    {
        public Guid Id { get; set; }
        public string VoyageNo { get; set; } = null!;
        public string NoticeNo { get; set; } = null!;
        public DateTime ETA { get; set; }
        public DateTime ETD { get; set; }
        public string ShipLine { get; set; } = null!;
        public string ShipAgent { get; set; } = null!;
        public string VesselName { get; set; } = null!;
        public string Imo { get; set; } = null!;
    }
}
