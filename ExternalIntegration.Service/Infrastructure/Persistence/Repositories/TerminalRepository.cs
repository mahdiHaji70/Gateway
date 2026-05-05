using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Repositories
{
    public class TerminalRepository : Repository<Terminal>, ITerminalRepository
    {
        public TerminalRepository(GatewayDbContext context): base(context) { }

        public async Task<Terminal?> GetByCodeAsync(string code)
        {
            return await _context.Terminals
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Code == code);
        }
    }
}
