using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface ITrafficRepository : IRepository<Traffic>
    {
        Task<PagedResult<Traffic>?> GetPagedAsync(int pageNumber, int pageSize, string? search);
        Task<List<Traffic>> GetByCodesAsync(IEnumerable<string> codes, CancellationToken cancellationToken);
    }
}
