using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
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
           .Include(x => x.ManifestItem);

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
    }
}
