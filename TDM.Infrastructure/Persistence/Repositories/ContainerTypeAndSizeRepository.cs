using Microsoft.EntityFrameworkCore;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class ContainerTypeAndSizeRepository : Repository<ContainerTypeAndSize>, IContainerTypeAndSizeRepository
    {
        public ContainerTypeAndSizeRepository(TDMDbContext context) : base(context)
        {
        }

        public async Task<PagedResult<ContainerTypeAndSize>?> GetPagedAsync(int pageNumber, int pageSize, string? search)
        {
            var query = _dbSet.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchTerm = search.Trim();
                query = query.Where(x =>
                    (x.TypeAndSize != null && x.TypeAndSize.Contains(searchTerm)) ||
                    (x.TypeAndSizeCode != null && x.TypeAndSizeCode.Contains(searchTerm)));
            }

            var totalCount = await query.CountAsync();
            var items = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<ContainerTypeAndSize>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
