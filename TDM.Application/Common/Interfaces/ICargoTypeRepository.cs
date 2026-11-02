using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface ICargoTypeRepository : IRepository<CargoType>
    {
        Task<PagedResult<CargoType>?> GetPagedAsync(int pageNumber, int pageSize, string? search);
    }
}
