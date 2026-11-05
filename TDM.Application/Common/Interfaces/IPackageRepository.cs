using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IPackageRepository : IRepository<Package>
    {
        Task<PagedResult<Package>?> GetPagedAsync(int pageNumber, int pageSize, string? search);
        Task<List<Package>> GetByCodesAsync(IEnumerable<string> codes, CancellationToken cancellationToken);
    }
}
