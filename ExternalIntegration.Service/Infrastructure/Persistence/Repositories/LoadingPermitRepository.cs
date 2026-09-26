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
                .Where(x => x.WarehouseReceiptId == warehouseReceiptId)
                .OrderByDescending(x => x.ExpirationDate)
                .FirstOrDefaultAsync();
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
                .Select(x => x.OrderByDescending(entity => entity.ExpirationDate).First())
                .ToList();

            if (entityList.Count == 0)
                return new List<LoadingPermit>();

            var incomingIds = entityList
                .Select(x => x.Id)
                .ToList();

            var latestExpirationDates = await _loadingPermitDbSet
                .AsNoTracking()
                .Where(x => incomingIds.Contains(x.Id))
                .GroupBy(x => x.Id)
                .Select(group => new
                {
                    Id = group.Key,
                    ExpirationDate = group.Max(x => x.ExpirationDate)
                })
                .ToDictionaryAsync(x => x.Id, x => x.ExpirationDate);

            return entityList
                .Where(x => !latestExpirationDates.TryGetValue(x.Id, out var latestExpirationDate)
                    || x.ExpirationDate > latestExpirationDate)
                .ToList();
        }

        public void UpdateLoadingPermitApprovedAsync(Guid permitId, bool isApproved)
        {
            var record = _loadingPermitDbSet
                .Where(t => t.Id == permitId)
                .OrderByDescending(t => t.ExpirationDate)
                .FirstOrDefault();
            record!.IsApproved = isApproved;
            _loadingPermitDbSet.Update(record);
        }
    }
}
