using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Repositories
{
    public class ThroughTransportRepository : Repository<ThroughTransport>, IThroughTransportRepository
    {
        public ThroughTransportRepository(GatewayDbContext context) : base(context) { }

        public async Task<DateTime> GetLastDateAsync(string terminalCode)
        {
            return await _dbSet.Where(x => x.TerminalCode == terminalCode)
                .OrderByDescending(x => x.Date).Select(x => x.Date).FirstOrDefaultAsync();
        }
    }
}
