using TDM.Application.Doc.StoreReceipts.Commands.SendVesselLoadingToIpas;
using TDM.Infrastructure.Integrations.Requests;

namespace TDM.Infrastructure.Integrations.Mapper
{
    public class SendVesselLoadingToIpasMapper
    {
        public static SendVesselLoadingToIpasResponse Map(Guid response, Guid storeExitDocumentId)
        {
            return new SendVesselLoadingToIpasResponse
            {
                StoreExitDocumentId = storeExitDocumentId,
                IpasVesselLoadingId = response,
                IsSent = true
            };
        }

        public static SendVesselLoadingToIpasDto Map(SendVesselLoadingToIpasRequest request)
        {
            return new SendVesselLoadingToIpasDto
            {
                TerminalCode = request.TerminalCode,
                Date = request.Date,
                VoyageId = request.VoyageId,
                StartTime = request.StartTime,
                FinishTime = request.FinishTime,
                CarrierIdNumber = request.CarrierIdNumber,
                CarrierType = request.CarrierType,
                TallyMan = request.TallyMan,
                Remark = request.Remark,
                GeneralCargoList = request.GeneralCargoList,
                BulkList = request.BulkList,
                ContainerList = request.ContainerList
            };
        }
    }
}
