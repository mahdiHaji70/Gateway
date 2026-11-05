

using Microsoft.EntityFrameworkCore;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(TDMDbContext context) : base(context)
        {
        }

        public async override Task<PagedResult<City>?> GetPagedAsync(int pageNumber, int pageSize)
        {
            IQueryable<City> query = _dbSet
           .AsNoTracking()
           .Include(x => x.Country);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<City>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<PagedResult<City>?> GetPagedAsync(int pageNumber, int pageSize, string? search)
        {
            IQueryable<City> query = _dbSet
                .AsNoTracking()
                .Include(x => x.Country);

            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchTerm = search.Trim();
                query = query.Where(x =>
                    (x.Name != null && x.Name.Contains(searchTerm)) ||
                    (x.Code != null && x.Code.Contains(searchTerm)));
            }

            var totalCount = await query.CountAsync();
            var items = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<City>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async override Task<City?> GetAsync(Guid id)
        {
            return await _dbSet
                        .AsNoTracking()
                        .Include(x => x.Country)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
