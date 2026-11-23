using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IStoreExitDocumentRepository : IRepository<StoreExitDocument>
    {
        Task<StoreExitDocument?> GetForLandDeliveryAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
