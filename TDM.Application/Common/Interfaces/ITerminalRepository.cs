using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface ITerminalRepository : IRepository<Terminal>
    {
        Task<PagedResult<Terminal>?> GetPagedAsync(int pageNumber, int pageSize, string? search);
    }
}
