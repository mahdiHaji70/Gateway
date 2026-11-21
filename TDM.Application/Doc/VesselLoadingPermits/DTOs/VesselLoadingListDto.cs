namespace TDM.Application.Doc.VesselLoadingPermits.DTOs
{
    public class VesselLoadingListDto
    {
        public Guid Id { get; set; }
        public VesselLoadingListVoyageDto? Voyage { get; set; }
    }

    public class VesselLoadingListVoyageDto
    {
        public string? VoyageNo { get; set; }
        public string? NoticeNo { get; set; }
        public VesselLoadingListVesselDataDto? VesselData { get; set; }
    }

    public class VesselLoadingListVesselDataDto
    {
        public string? Name { get; set; }
        public string? Imo { get; set; }
    }
}
