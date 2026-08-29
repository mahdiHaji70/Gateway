using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Repositories
{
    public class VesselLoadingPermitRepository : Repository<VesselLoadingPermit>, IVesselLoadingPermitRepository
    {
        protected readonly DbSet<VesselLoadingPermit> _vesselLoadingPermitDbSet;

        public VesselLoadingPermitRepository(GatewayDbContext context) : base(context) 
        {
            _vesselLoadingPermitDbSet = _context.Set<VesselLoadingPermit>();
        }

        public async Task<DateTime> GetLastDateAsync(string terminalCode)
        {
            return await _vesselLoadingPermitDbSet
                .Where(x => x.TerminalCode == terminalCode)
                .OrderByDescending(x => x.Date).Select(x => x.Date).FirstOrDefaultAsync();
        }
    }
}
