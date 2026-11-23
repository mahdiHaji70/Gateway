using TDM.Application.Doc.StoreReceipts.Commands.SendSeaExitDeliveryToIpas;
using TDM.Infrastructure.Integrations.Requests;

namespace TDM.Infrastructure.Integrations.Mapper
{
    public class SendSeaExitDeliveryToIpasMapper
    {
        public static SendSeaExitDeliveryToIpasResponse Map(Guid response, Guid storeExitDocumentId)
        {
            return new SendSeaExitDeliveryToIpasResponse
            {
                StoreExitDocumentId = storeExitDocumentId,
                IpasDeliveryId = response,
                IsSent = true
            };
        }

        public static SendSeaExitDeliveryToIpasDto Map(SendSeaExitDeliveryToIpasRequest request)
        {
            return new SendSeaExitDeliveryToIpasDto
            {
                LoadingPermitId = request.LoadingPermitId,
                TerminalCode = request.TerminalCode,
                Date = request.Date,
                VehicleTypeId = request.VehicleTypeId,
                VehicleNo = request.VehicleNo,
                LoadingStart = request.LoadingStart,
                LoadingFinish = request.LoadingFinish,
                Remark = request.Remark,
                GeneralCargoList = request.GeneralCargoList,
                BulkList = request.BulkList,
                ContainerList = request.ContainerList
            };
        }
    }
}
