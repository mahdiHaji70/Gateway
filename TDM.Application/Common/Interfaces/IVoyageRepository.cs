using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IVoyageRepository : IRepository<Voyage>
    {
        Task<DateTime> GetLastNoticeDateAsync(CancellationToken cancellationToken = default);
        Task<List<Voyage>> GetByIpasIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
        Task<PagedResult<Voyage>?> GetPagedAsync(int pageNumber, int pageSize, string? search);
    }
}