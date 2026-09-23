using TDM.Application.Doc.LoadingPermits.DTOs;

namespace TDM.Application.Common.Interfaces
{
    public interface ILoadingPermitExternalService
    {
        Task<LoadingPermitDto> GetLoadingPermitRequest(
            Guid warehouseReceiptId,
            CancellationToken cancellationToken = default);

        Task<bool> ConfirmLoadingPermit(
            Guid permitId,
            string terminalCode,
            bool isApproved,
            string description,
            CancellationToken cancellationToken = default);
    }
}
