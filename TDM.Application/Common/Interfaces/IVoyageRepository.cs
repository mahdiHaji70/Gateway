using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IVoyageRepository : IRepository<Voyage>
    {
        Task<PagedResult<Voyage>?> GetPagedAsync(int pageNumber, int pageSize, string? search);
    }
}