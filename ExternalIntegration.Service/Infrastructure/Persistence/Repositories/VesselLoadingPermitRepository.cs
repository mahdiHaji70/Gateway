using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public async Task<VesselLoadingPermit?> GetByWarehouseReceiptIdAsync(Guid warehouseReceiptId)
        {
            return await _vesselLoadingPermitDbSet
                .AsNoTracking()
                .Where(x => x.WarehouseReceiptId == warehouseReceiptId && x.IsApproved == false)
                .OrderByDescending(x => x.ExpirationDate)
                .FirstOrDefaultAsync();
        }

        public override Task<List<VesselLoadingPermit>> FilterUnpersistedAsync<TId>(
            IEnumerable<VesselLoadingPermit> entities,
            Func<VesselLoadingPermit, TId> idSelector,
            Expression<Func<VesselLoadingPermit, TId>> dbIdSelector)
        {
            return FilterUnpersistedAsync(entities);
        }

        public async Task<List<VesselLoadingPermit>> FilterUnpersistedAsync(
            IEnumerable<VesselLoadingPermit> entities)
        {
            var entityList = entities
                .GroupBy(x => x.Id)
                .Select(x => x.OrderByDescending(entity => entity.ExpirationDate).First())
                .ToList();

            if (entityList.Count == 0)
                return new List<VesselLoadingPermit>();

            var incomingIds = entityList
                .Select(x => x.Id)
                .ToList();

            var latestExpirationDates = await _vesselLoadingPermitDbSet
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

        public void UpdateVesselLoadingPermitApprovedAsync(Guid id, bool isApproved)
        {
            var record = _vesselLoadingPermitDbSet
                .Where(t => t.Id == id)
                .OrderByDescending(t => t.ExpirationDate)
                .FirstOrDefault();
            record!.IsApproved = isApproved;
            _vesselLoadingPermitDbSet.Update(record);
        }
    }
}
