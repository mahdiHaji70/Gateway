using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Repositories
{
 
    public class VoyageRepository : Repository<Voyage>, IVoyageRepository
    {
        protected readonly DbSet<Voyage> _VoyageDbSet;

        public VoyageRepository(GatewayDbContext context) : base(context)
        {
            _VoyageDbSet = _context.Set<Voyage>();
        }

        public async Task<List<Voyage>> GetFromDateAsync(DateTime lastDate, CancellationToken cancellationToken = default)
        {
            return await _VoyageDbSet
                .AsNoTracking()
                .Where(x => x.NoticeDate >= lastDate)
                .OrderBy(x => x.NoticeDate)
                .ThenBy(x => x.Id)
                .ToListAsync(cancellationToken);
        }

        public async Task<DateTime> GetLastDateAsync()
        {
            return await _VoyageDbSet.OrderByDescending(x => x.NoticeDate).Select(x => x.NoticeDate).FirstOrDefaultAsync();
        }
    }
}
