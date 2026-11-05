using Microsoft.EntityFrameworkCore;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class PackageRepository : Repository<Package>, IPackageRepository
    {
        public PackageRepository(TDMDbContext context) : base(context)
        {
        }

        public async Task<PagedResult<Package>?> GetPagedAsync(int pageNumber, int pageSize, string? search)
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
            var items = await query.OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedResult<Package> { Items = items, TotalCount = totalCount, PageNumber = pageNumber, PageSize = pageSize };
        }

        public async Task<List<Package>> GetByCodesAsync(IEnumerable<string> codes, CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().Where(x => codes.Contains(x.Code)).ToListAsync(cancellationToken);
        }
    }
}
