namespace TDM.Infrastructure.Integrations.Responses
{
    public class VesselLoadingListResponseDto
    {
        public Guid Id { get; set; }
        public VesselLoadingListVoyageResponseDto? Voyage { get; set; }
    }

    public class VesselLoadingListVoyageResponseDto
    {
        public string? VoyageNo { get; set; }
        public string? NoticeNo { get; set; }
        public VesselLoadingListVesselDataResponseDto? VesselData { get; set; }
    }

    public class VesselLoadingListVesselDataResponseDto
    {
        public string? Name { get; set; }
        public string? Imo { get; set; }
    }
}
