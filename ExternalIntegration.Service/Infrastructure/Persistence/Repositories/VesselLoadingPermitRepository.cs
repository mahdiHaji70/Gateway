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
                .FirstOrDefaultAsync(x => x.WarehouseReceiptId == warehouseReceiptId && x.IsApproved == false);
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
                .Select(x => x.First())
                .ToList();

            if (entityList.Count == 0)
                return new List<VesselLoadingPermit>();

            var incomingIds = entityList
                .Select(x => x.Id)
                .ToList();

            var persistedIds = await _vesselLoadingPermitDbSet
                .AsNoTracking()
                .Where(x => incomingIds.Contains(x.Id))
                .Select(x => x.Id)
                .ToListAsync();

            var persistedIdSet = persistedIds.ToHashSet();

            return entityList
                .Where(x => !persistedIdSet.Contains(x.Id))
                .ToList();
        }

        public async void UpdateVesselLoadingPermitApprovedAsync(Guid id, bool isApproved)
        {
            var record = _vesselLoadingPermitDbSet.FirstOrDefault(t => t.Id == id);
            record!.IsApproved = isApproved;
            _vesselLoadingPermitDbSet.Update(record);
        }
    }
}
