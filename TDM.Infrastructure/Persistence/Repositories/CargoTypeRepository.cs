

using Microsoft.EntityFrameworkCore;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class CargoTypeRepository : Repository<CargoType>, ICargoTypeRepository
    {
        public CargoTypeRepository(TDMDbContext context) : base(context)
        {
        }

        public async Task<PagedResult<CargoType>?> GetPagedAsync(int pageNumber, int pageSize, string? search)
        {
            var query = _dbSet.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(x => x.Name != null && x.Name.Contains(search.Trim()));

            var totalCount = await query.CountAsync();
            var items = await query.OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedResult<CargoType> { Items = items, TotalCount = totalCount, PageNumber = pageNumber, PageSize = pageSize };
        }
              
    }
}
