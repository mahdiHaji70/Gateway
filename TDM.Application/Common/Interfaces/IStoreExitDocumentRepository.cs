using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IStoreExitDocumentRepository : IRepository<StoreExitDocument>
    {
        Task<StoreExitDocument?> GetForVesselLoadingAsync(Guid id, CancellationToken cancellationToken = default);
        Task<StoreExitDocument?> GetForSeaDeliveryAsync(Guid id, CancellationToken cancellationToken = default);
        Task<StoreExitDocument?> GetForLandDeliveryAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
