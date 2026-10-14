using Microsoft.EntityFrameworkCore;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(TDMDbContext context) : base(context)
        {
        }

        public async Task<List<Service>> GetByCodesAsync(IEnumerable<string> codes, CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().Where(x => codes.Contains(x.Code)).ToListAsync(cancellationToken);
        }
    }
}
