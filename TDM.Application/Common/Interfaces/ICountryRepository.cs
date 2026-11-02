using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface ICountryRepository : IRepository<Country>
    {
        Task<PagedResult<Country>?> GetPagedAsync(int pageNumber, int pageSize, string? search);
    }
}
