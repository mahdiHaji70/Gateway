using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IContainerRepository : IRepository<Container>
    {
        Task<PagedResult<Container>?> GetPagedAsync(int pageNumber, int pageSize, string? search);
        Task<List<Container>> GetByNoAndCodesAsync(IEnumerable<(string, string)> codes, CancellationToken cancellationToken);

    }
}
