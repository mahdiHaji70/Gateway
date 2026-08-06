using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Repositories
{
    public class ManifestRepository : Repository<Manifest>, IManifestRepository
    {
        protected readonly DbSet<Manifest> _manifestDbSet;

        public ManifestRepository(GatewayDbContext context) : base(context)
        {
            _manifestDbSet = _context.Set<Manifest>();
        }

        public async Task<DateTime> GetLastDateAsync(string terminalCode)
        {
            return await _manifestDbSet
                .Where(x => x.TerminalCodeDischarge == terminalCode)
                .OrderByDescending(x => x.CreationDate).Select(x => x.CreationDate).FirstOrDefaultAsync();
        }
    }
}
