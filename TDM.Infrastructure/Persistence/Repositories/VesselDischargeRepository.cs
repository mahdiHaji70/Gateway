using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Application.Operation.VesselDischarges.DTOs;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class VesselDischargeRepository : Repository<VesselDischarge>, IVesselDischargeRepository
    {
        public VesselDischargeRepository(TDMDbContext context) : base(context)
        {
        }

        public async override Task<PagedResult<VesselDischarge>?> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _dbSet
           .AsNoTracking()
           .Include(x => x.Store)
           .Include(x => x.ManifestItem)
           .Include(x => x.ManifestContainer)
            .ThenInclude(x => x!.Container);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<VesselDischarge>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }


        public async override Task<VesselDischarge?> GetAsync(Guid id)
        {
            return await _dbSet
                        .AsNoTracking()
                        .Include(x => x.Store)
                        .Include(x => x.ManifestItem)
                        .Include(x => x.ManifestContainer)
                            .ThenInclude(x => x!.Container)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<VesselDischarge>> GetUnsentVesselDischargesToIpasAsync(Guid manifestItemId)
        {
            return await _dbSet
                .Include(x => x.Store)
                .Include(x => x.ManifestItem)
                    .ThenInclude(x => x.ManifestGoods)
                .Include(x => x.ManifestItem)
                    .ThenInclude(x => x.ManifestContainers)
                    .ThenInclude(x => x.ManifestContainerGoods)
                .Include(x => x.ManifestContainer!)
                .ThenInclude(x => x.ManifestContainerGoods)
                .Where(x => x.ManifestItemId == manifestItemId && x.IpasVesselDischargeId == null)
                .ToListAsync();
        }

        public async Task<bool> ExistsByManifestContainerIdAsync(Guid manifestContainerId, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .AsNoTracking()
                .AnyAsync(x => x.ManifestContainerId == manifestContainerId, cancellationToken);
        }

        public async Task<List<VesselDischarge>> GetByManifestItemIdAsync(Guid manifestItemId, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(x => x.Store)
                .Include(x => x.ManifestItem)
                .Include(x => x.ManifestContainer)
                    .ThenInclude(x => x!.Container)
                .Where(x => x.ManifestItemId == manifestItemId)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync(cancellationToken);
        }

        public async Task<List<GroupedVesselDischargeDto>> GetGroupedAsync(
            Guid manifestItemId,
            CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(x => x.ManifestItemId == manifestItemId
                    && x.IpasVesselDischargeId != null)
                .GroupBy(x => new
                {
                    x.TerminalCode,
                    x.StoreId,
                    StoreName = x.Store.Name,
                    x.ManifestItemId,
                    ManifestItemNo = x.ManifestItem.ManifestItemNo,
                    ManifestNo = x.ManifestItem.ManifestNo,
                    x.ManifestContainerId,
                    ContainerNo = x.ManifestContainer == null
                        ? null
                        : x.ManifestContainer.Container.No,
                    x.DischargeDate,
                    x.IsNonPalletized,
                    x.IsDamaged,
                    x.IsVoluminous,
                    x.IsDangerous,
                    x.DangerousCode,
                    x.Classification,
                    x.IgnitionTemperature,
                    x.IgnitionTemperatureUnit,
                    x.IpasVesselDischargeId,
                    x.IpasVesselDischargeReceivedAt,
                    x.UnitWeight
                })
                .Select(group => new GroupedVesselDischargeDto
                {
                    TerminalCode = group.Key.TerminalCode,
                    StoreId = group.Key.StoreId,
                    StoreName = group.Key.StoreName,
                    ManifestItemId = group.Key.ManifestItemId,
                    ManifestItemNo = group.Key.ManifestItemNo,
                    ManifestNo = group.Key.ManifestNo,
                    ManifestContainerId = group.Key.ManifestContainerId,
                    ContainerNo = group.Key.ContainerNo,
                    DischargeDate = group.Key.DischargeDate,
                    PackNB = group.Sum(x => x.PackNB),
                    Weight = group.Sum(x => x.Weight),
                    Volume = group.Sum(x => x.Volume),
                    IsNonPalletized = group.Key.IsNonPalletized,
                    IsDamaged = group.Key.IsDamaged,
                    IsVoluminous = group.Key.IsVoluminous,
                    IsDangerous = group.Key.IsDangerous,
                    DangerousCode = group.Key.DangerousCode,
                    Classification = group.Key.Classification,
                    IgnitionTemperature = group.Key.IgnitionTemperature,
                    IgnitionTemperatureUnit = group.Key.IgnitionTemperatureUnit,
                    IpasVesselDischargeId = group.Key.IpasVesselDischargeId,
                    IpasVesselDischargeReceivedAt = group.Key.IpasVesselDischargeReceivedAt,
                    UnitWeight = group.Key.UnitWeight,
                    IsSend = group.Key.IpasVesselDischargeId != null
                })
                .ToListAsync(cancellationToken);
        }
    }
}
