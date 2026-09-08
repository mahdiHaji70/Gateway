using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Repositories
{
    public class LoadingPermitRepository : Repository<LoadingPermit>, ILoadingPermitRepository
    {
        protected readonly DbSet<LoadingPermit> _loadingPermitDbSet;

        public LoadingPermitRepository(GatewayDbContext context) : base(context) 
        {
            _loadingPermitDbSet = _context.Set<LoadingPermit>();
        }

        public async Task<DateTime> GetLastDateAsync(string terminalCode)
        {
            return await _loadingPermitDbSet
                .Where(x => x.TerminalCode == terminalCode)
                .OrderByDescending(x => x.Date).Select(x => x.Date).FirstOrDefaultAsync();
        }

        public async void UpdateLoadingPermitApprovedAsync(Guid permitId, bool isApproved)
        {
            var record = _loadingPermitDbSet.FirstOrDefault(t => t.Id == permitId);
            record!.IsApproved = isApproved;
            _loadingPermitDbSet.Update(record);
        }
    }
}
