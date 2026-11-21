using TDM.Application.Doc.VesselLoadingPermits.DTOs;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Mapper
{
    public static class VesselLoadingListMapper
    {
        public static VesselLoadingListDto Map(VesselLoadingListResponseDto source)
        {
            return new VesselLoadingListDto
            {
                Id = source.Id,
                Voyage = source.Voyage == null
                    ? null
                    : new VesselLoadingListVoyageDto
                    {
                        VoyageNo = source.Voyage.VoyageNo,
                        NoticeNo = source.Voyage.NoticeNo,
                        VesselData = source.Voyage.VesselData == null
                            ? null
                            : new VesselLoadingListVesselDataDto
                            {
                                Name = source.Voyage.VesselData.Name,
                                Imo = source.Voyage.VesselData.Imo
                            }
                    }
            };
        }
    }
}
