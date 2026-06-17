

using Microsoft.EntityFrameworkCore;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class ContainerRepository : Repository<Container>, IContainerRepository
    {
        public ContainerRepository(TDMDbContext context) : base(context)
        {
        }

        public async override Task<PagedResult<Container>?> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _dbSet
           .AsNoTracking()
           .Include(x => x.ContainerTypeAndSize);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Container>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async override Task<Container?> GetAsync(Guid id)
        {
            return await _dbSet
                        .AsNoTracking()
                        .Include(x => x.ContainerTypeAndSize)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Container>> GetByNoAndCodesAsync(IEnumerable<(string, string)> codes, CancellationToken cancellationToken)
        {
            if (codes == null || !codes.Any())
                return new List<Container>();

            IQueryable<Container> query = _dbSet.AsNoTracking().Where(x => false);

            foreach (var (no, typeCode) in codes)
            {
                var tempNo = no;
                var tempTypeCode = typeCode;

                query = query.Union(
                    _dbSet.AsNoTracking()
                          .Where(x => x.No == tempNo && x.ContainerTypeAndSize.TypeAndSizeCode == tempTypeCode)
                );
            }

            return await query.ToListAsync(cancellationToken);

        }
    }
}
