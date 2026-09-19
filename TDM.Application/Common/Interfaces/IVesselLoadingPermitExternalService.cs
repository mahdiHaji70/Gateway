using TDM.Application.Doc.VesselLoadingPermits.DTOs;

namespace TDM.Application.Common.Interfaces
{
    public interface IVesselLoadingPermitExternalService
    {
        Task<VesselLoadingPermitDto> GetVesselLoadingPermitRequest(
            Guid warehouseReceiptId,
            CancellationToken cancellationToken = default);

        Task<bool> ConfirmVesselLoadingPermit(
            Guid id,
            string terminalCode,
            bool isApproved,
            string remark,
            CancellationToken cancellationToken = default);
    }
}
