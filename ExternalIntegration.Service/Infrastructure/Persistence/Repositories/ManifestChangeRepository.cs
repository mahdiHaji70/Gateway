using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Repositories
{
    public class ManifestChangeRepository : Repository<ManifestChange>, IManifestChangeRepository
    {
        protected readonly DbSet<ManifestChange> _manifestChangeDbSet;

        public ManifestChangeRepository(GatewayDbContext context) : base(context)
        {
            _manifestChangeDbSet = _context.Set<ManifestChange>();
        }
       
        public async Task<DateTime> GetLastDateAsync(string terminalCode)
        {
            return await _manifestChangeDbSet
                .Where(x => x.TerminalCode == terminalCode)
                .OrderByDescending(x => x.Date).Select(x => x.Date).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ManifestChange>> GetByTerminalCode(string terminalCode)
        {
            return await _manifestChangeDbSet
                .Where(x => x.TerminalCode == terminalCode)
                .ToListAsync();
        }

    }
}
