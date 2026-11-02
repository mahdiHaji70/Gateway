using Microsoft.EntityFrameworkCore;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(TDMDbContext context) : base(context)
        {
        }

        public async Task<List<Company>> GetByNationalIdsAsync(IEnumerable<string> nationalIds, CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().Where(x => nationalIds.Contains(x.NationalId)).ToListAsync(cancellationToken);
        }

        public async Task<PagedResult<Company>?> GetPagedAsync(int pageNumber, int pageSize, string? search)
        {
            var query = _dbSet.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchTerm = search.Trim();
                query = query.Where(x =>
                    (x.Name != null && x.Name.Contains(searchTerm)) ||
                    (x.NationalId != null && x.NationalId.Contains(searchTerm)) ||
                    (x.EconomicCode != null && x.EconomicCode.Contains(searchTerm)) ||
                    (x.RegisterNumber != null && x.RegisterNumber.Contains(searchTerm)));
            }

            var totalCount = await query.CountAsync();
            var items = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Company>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
