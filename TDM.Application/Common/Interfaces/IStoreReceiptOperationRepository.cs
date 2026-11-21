using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IStoreReceiptOperationRepository : IRepository<StoreReceiptOperation>
    {
        Task<StoreReceiptOperation?> GetEarliestDischargeOperationAsync(
            Guid storeReceiptId,
            string terminalCode,
            CancellationToken cancellationToken = default);
    }
}
