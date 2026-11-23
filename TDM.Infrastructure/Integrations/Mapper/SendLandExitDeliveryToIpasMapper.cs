using TDM.Application.Doc.StoreReceipts.Commands.SendLandExitDeliveryToIpas;
using TDM.Infrastructure.Integrations.Requests;
using TDM.Infrastructure.Integrations.Responses;

namespace TDM.Infrastructure.Integrations.Mapper
{
    public class SendLandExitDeliveryToIpasMapper
    {
        public static SendLandExitDeliveryToIpasResponse Map(SendLandExitDeliveryResultDto response, Guid storeExitDocumentId)
        {
            return new SendLandExitDeliveryToIpasResponse
            {
                StoreExitDocumentId = storeExitDocumentId,
                IpasDeliveryId = response.Id,
                IpasDeliverySerialNo = response.SerialNo,
                IsSent = true
            };
        }

        public static SendLandExitDeliveryToIpasDto Map(SendLandExitDeliveryToIpasRequest request)
        {
            return new SendLandExitDeliveryToIpasDto
            {
                LoadingPermitId = request.LoadingPermitId,
                TerminalCode = request.TerminalCode,
                Date = request.Date,
                VehicleTypeId = request.VehicleTypeId,
                VehicleNo = request.VehicleNo,
                LoadingStart = request.LoadingStart,
                LoadingFinish = request.LoadingFinish,
                Remark = request.Remark,
                StorageAreaCode = request.StorageAreaCode,
                FirstPortDischargeDate = request.FirstPortDischargeDate,
                FirstTerminalDischargeDate = request.FirstTerminalDischargeDate,
                GeneralCargoList = request.GeneralCargoList,
                BulkList = request.BulkList,
                ContainerList = request.ContainerList
            };
        }
    }
}
