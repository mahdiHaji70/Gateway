using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task<PagedResult<Service>?> GetPagedAsync(int pageNumber, int pageSize, string? search);
        Task<List<Service>> GetByCodesAsync(IEnumerable<string> codes, CancellationToken cancellationToken);
    }
}
