

using Microsoft.EntityFrameworkCore;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class UserTerminalRepository : Repository<UserTerminal>, IUserTerminalRepository
    {
        public UserTerminalRepository(TDMDbContext context) : base(context)
        {
        }

        public async override Task<PagedResult<UserTerminal>?> GetPagedAsync(int pageNumber, int pageSize)
        {
            IQueryable<UserTerminal> query = _dbSet
           .AsNoTracking()
           .Include(x => x.Terminal);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<UserTerminal>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<PagedResult<UserTerminal>?> GetPagedAsync(int pageNumber, int pageSize, string? search)
        {
            IQueryable<UserTerminal> query = _dbSet
                .AsNoTracking()
                .Include(x => x.Terminal);

            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchTerm = search.Trim();
                query = query.Where(x =>
                    (x.UserNationalId != null && x.UserNationalId.Contains(searchTerm)) ||
                    (x.Terminal.Code != null && x.Terminal.Code.Contains(searchTerm)) ||
                    (x.Terminal.Name != null && x.Terminal.Name.Contains(searchTerm)));
            }

            var totalCount = await query.CountAsync();
            var items = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<UserTerminal>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async override Task<UserTerminal?> GetAsync(Guid id)
        {
            return await _dbSet
                        .AsNoTracking()
                        .Include(x => x.Terminal)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> ExistsByNationalId(string nationalId)
        {
            return await _dbSet.AnyAsync(x => x.UserNationalId == nationalId);
        }

        public async Task<UserTerminal?> GetByNationalId(string nationalId)
        {
            return await _dbSet
                        .AsNoTracking()
                        .Include(x => x.Terminal)
                        .FirstOrDefaultAsync(x => x.UserNationalId == nationalId);
        }
    }
}
