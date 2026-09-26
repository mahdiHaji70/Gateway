using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<LoadingPermit?> GetByWarehouseReceiptIdAsync(Guid warehouseReceiptId)
        {
            return await _loadingPermitDbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.WarehouseReceiptId == warehouseReceiptId);
        }

        public override Task<List<LoadingPermit>> FilterUnpersistedAsync<TId>(
            IEnumerable<LoadingPermit> entities,
            Func<LoadingPermit, TId> idSelector,
            Expression<Func<LoadingPermit, TId>> dbIdSelector)
        {
            return FilterUnpersistedAsync(entities);
        }

        public async Task<List<LoadingPermit>> FilterUnpersistedAsync(
            IEnumerable<LoadingPermit> entities)
        {
            var entityList = entities
                .GroupBy(x => x.Id)
                .Select(x => x.First())
                .ToList();

            if (entityList.Count == 0)
                return new List<LoadingPermit>();

            var incomingIds = entityList
                .Select(x => x.Id)
                .ToList();

            var persistedIds = await _loadingPermitDbSet
                .AsNoTracking()
                .Where(x => incomingIds.Contains(x.Id))
                .Select(x => x.Id)
                .ToListAsync();

            var persistedIdSet = persistedIds.ToHashSet();

            return entityList
                .Where(x => !persistedIdSet.Contains(x.Id))
                .ToList();
        }

        public async void UpdateLoadingPermitApprovedAsync(Guid permitId, bool isApproved)
        {
            var record = _loadingPermitDbSet.FirstOrDefault(t => t.Id == permitId);
            record!.IsApproved = isApproved;
            _loadingPermitDbSet.Update(record);
        }
    }
}
