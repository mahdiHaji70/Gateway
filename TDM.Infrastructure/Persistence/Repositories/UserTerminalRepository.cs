

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
            var query = _dbSet
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
