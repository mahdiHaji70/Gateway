using ExternalIntegration.Service.Domain.Entities;

namespace ExternalIntegration.Service.Application.Abstractions
{
    public interface IVesselLoadingListRepository : IRepository<VesselLoadingList>
    {
        Task<VesselLoadingList?> GetByPermitIdAsync(
            Guid permitId,
            CancellationToken cancellationToken = default);
    }
}
