using TDM.Application.Doc.StoreReceipts.Commands.SendLandExitDeliveryToIpas;
using TDM.Infrastructure.Integrations.Requests;

namespace TDM.Infrastructure.Integrations.Mapper
{
    public class SendLandExitDeliveryToIpasMapper
    {
        public static SendLandExitDeliveryToIpasDto Map(SendLandExitDeliveryToIpasCommandRequest request)
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
