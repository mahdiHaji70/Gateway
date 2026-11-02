using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IContainerTypeAndSizeRepository : IRepository<ContainerTypeAndSize>
    {
        Task<PagedResult<ContainerTypeAndSize>?> GetPagedAsync(int pageNumber, int pageSize, string? search);
    }
}
