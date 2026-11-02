using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface ICommodityRepository : IRepository<Commodity>
    {
        Task<PagedResult<Commodity>?> GetPagedAsync(int pageNumber, int pageSize, string? search);
        Task<List<Commodity>> GetByHsCodesAsync(IEnumerable<string> hsCodes, CancellationToken cancellationToken);
    }
}
