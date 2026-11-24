using Microsoft.EntityFrameworkCore;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class VoyageRepository : Repository<Voyage>, IVoyageRepository
    {
        public VoyageRepository(TDMDbContext context) : base(context) { }

        public async Task<DateTime> GetLastNoticeDateAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.MaxAsync(x => x.NoticeDate, cancellationToken) ?? DateTime.MinValue;
        }

        public async Task<List<Voyage>> GetByIpasIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            var voyageIds = ids.Distinct().ToList();
            return await _dbSet
                .Where(x => x.IpasVoyageId.HasValue && voyageIds.Contains(x.IpasVoyageId.Value))
                .ToListAsync(cancellationToken);
        }

        public async Task<PagedResult<Voyage>?> GetPagedAsync(int pageNumber, int pageSize, string? search)
        {
            var query = _dbSet.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim();
                query = query.Where(x => x.VoyageNo.Contains(term) || x.NoticeNo.Contains(term)
                    || x.VesselName.Contains(term) || x.Imo.Contains(term)
                    || x.ShipLine.Contains(term) || x.ShipAgent.Contains(term));
            }

            var totalCount = await query.CountAsync();
            var items = await query.OrderByDescending(x => x.CreatedAt).ThenBy(x => x.Id)
                .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedResult<Voyage>
            {
                Items = items, TotalCount = totalCount, PageNumber = pageNumber, PageSize = pageSize
            };
        }
    }
}