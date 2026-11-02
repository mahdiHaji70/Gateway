using Microsoft.EntityFrameworkCore;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class CommodityRepository : Repository<Commodity>, ICommodityRepository
    {
        public CommodityRepository(TDMDbContext context) : base(context)
        {
        }

        public async Task<PagedResult<Commodity>?> GetPagedAsync(int pageNumber, int pageSize, string? search)
        {
            var query = _dbSet.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchTerm = search.Trim();
                query = query.Where(x =>
                    (x.Name != null && x.Name.Contains(searchTerm)) ||
                    (x.HsCode != null && x.HsCode.Contains(searchTerm)));
            }

            var totalCount = await query.CountAsync();
            var items = await query.OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedResult<Commodity> { Items = items, TotalCount = totalCount, PageNumber = pageNumber, PageSize = pageSize };
        }

        public async Task<List<Commodity>> GetByHsCodesAsync(IEnumerable<string> hsCodes, CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().Where(x => hsCodes.Contains(x.HsCode)).ToListAsync(cancellationToken);
        }
    }
}
