using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IOperationTypeRepository : IRepository<OperationType>
    {
        Task<PagedResult<OperationType>?> GetPagedAsync(int pageNumber, int pageSize, string? search);
        Task<List<OperationType>> GetByCodesAsync(IEnumerable<string> codes, CancellationToken cancellationToken);
    }
}
