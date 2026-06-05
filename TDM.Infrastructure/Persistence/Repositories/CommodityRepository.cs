using Microsoft.EntityFrameworkCore;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class CommodityRepository : Repository<Commodity>, ICommodityRepository
    {
        public CommodityRepository(TDMDbContext context) : base(context)
        {
        }

        public async Task<List<Commodity>> GetByHsCodesAsync(IEnumerable<string> hsCodes, CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().Where(x => hsCodes.Contains(x.HsCode)).ToListAsync(cancellationToken);
        }
    }
}