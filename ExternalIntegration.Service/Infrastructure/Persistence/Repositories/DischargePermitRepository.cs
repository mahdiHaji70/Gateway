using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Repositories
{
    public class DischargePermitRepository : Repository<DischargePermit>, IDischargePermitRepository
    {
        protected readonly DbSet<DischargePermit> _dischargePermitDbSet;

        public DischargePermitRepository(GatewayDbContext context) : base(context) 
        {
            _dischargePermitDbSet = _context.Set<DischargePermit>();
        }

        public async Task<DateTime> GetLastDateAsync()
        {
            return await _dischargePermitDbSet.OrderByDescending(x => x.Date).Select(x => x.Date).FirstOrDefaultAsync();
        }
    }
}
