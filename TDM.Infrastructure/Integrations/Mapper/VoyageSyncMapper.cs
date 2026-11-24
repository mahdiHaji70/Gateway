using TDM.Application.Doc.Voyages.DTOs;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Mapper
{
    public static class VoyageSyncMapper
    {
        public static VoyageSyncDto Map(VoyageSyncResponseDto response)
        {
            return new VoyageSyncDto
            {
                IpasVoyageId = response.Id,
                NoticeDate = response.NoticeDate,
                VoyageNo = response.VoyageNo,
                NoticeNo = response.NoticeNo,
                ETA = response.Eta,
                ETD = response.Etd,
                ShipLine = response.ShippingLine,
                ShipAgent = response.ShippingAgent,
                VesselName = response.VesselData?.Name ?? string.Empty,
                Imo = response.VesselData?.Imo ?? string.Empty
            };
        }
    }
}
