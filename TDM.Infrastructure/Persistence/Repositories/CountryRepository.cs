using Microsoft.EntityFrameworkCore;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(TDMDbContext context) : base(context)
        {
        }

        public async Task<PagedResult<Country>?> GetPagedAsync(int pageNumber, int pageSize, string? search)
        {
            var query = _dbSet.AsNoTracking();

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

            return new PagedResult<Country>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
