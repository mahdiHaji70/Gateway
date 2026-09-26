using ExternalIntegration.Service.Domain.Entities;

namespace ExternalIntegration.Service.Application.Abstractions
{

    public interface ILoadingPermitRepository : IRepository<LoadingPermit>
    {
        Task<DateTime> GetLastDateAsync(string terminalCode);
        Task<LoadingPermit?> GetByWarehouseReceiptIdAsync(Guid warehouseReceiptId);
        Task<List<LoadingPermit>> FilterUnpersistedAsync(
            IEnumerable<LoadingPermit> entities);
        void UpdateLoadingPermitApprovedAsync(Guid permitId, bool isApproved);
    }
}
