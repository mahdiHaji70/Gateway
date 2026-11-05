using TDM.Domain.Entities;
using TDM.Application.Common.Models;

namespace TDM.Application.Common.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<List<Company>> GetByNationalIdsAsync(IEnumerable<string> nationalIds, CancellationToken cancellationToken);
        Task<PagedResult<Company>?> GetPagedAsync(int pageNumber, int pageSize, string? search);
    }
}
