using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Repositories
{
    public class TerminalRepository : Repository<Terminal>, ITerminalRepository
    {
        protected readonly DbSet<Terminal> terminalDbSet;

        public TerminalRepository(GatewayDbContext context): base(context)
        {
            terminalDbSet = _context.Set<Terminal>();
        }

        public async Task<Terminal?> GetByCodeAsync(string code)
        {
            return await terminalDbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Code == code);
        }
    }
}
