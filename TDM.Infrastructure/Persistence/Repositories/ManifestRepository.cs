using Microsoft.EntityFrameworkCore;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Application.Doc.Manifests.DTOs;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class ManifestRepository : Repository<Manifest>, IManifestRepository
    {
        public ManifestRepository(TDMDbContext context) : base(context)
        {
        }

        public async Task<bool> ExistsByNoticeNo(string noticeNo)
        {
            return await _dbSet.AnyAsync(x => x.NoticeNo == noticeNo);
        }

        public async Task<PagedResult<ManifestListDto>> GetPagedManifests(int pageNumber, int pageSize, string terminalCode)
        {
            var query = _dbSet.Where(x => x.TerminalCode == terminalCode).AsNoTracking();

            var totalCount = await query.CountAsync();

            var manifests = await _dbSet
                .AsNoTracking()
                .Where(x => x.TerminalCode == terminalCode)
                .OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(x => x.ManifestItems)
                    .ThenInclude(x => x.Traffic)
                .Include(x => x.ManifestItems)
                    .ThenInclude(x => x.Consignee)
                .Include(x => x.ManifestItems)
                    .ThenInclude(x => x.CargoType)
                .Include(x => x.ManifestItems)
                    .ThenInclude(x => x.ManifestGoods)
                        .ThenInclude(x => x.Commodity)
                .Include(x => x.ManifestItems)
                    .ThenInclude(x => x.ManifestGoods)
                        .ThenInclude(x => x.Package)
                .Include(x => x.ManifestItems)
                    .ThenInclude(x => x.ManifestContainers)
                        .ThenInclude(x => x.Container)
                .Include(x => x.ManifestItems)
                    .ThenInclude(x => x.ManifestContainers)
                        .ThenInclude(x => x.ManifestContainerGoods)
                .ToListAsync();

            var result = new List<ManifestListDto>();

            foreach (var manifest in manifests)
            {
                foreach (var item in manifest.ManifestItems)
                {
                    foreach (var good in item.ManifestGoods)
                    {
                        result.Add(new ManifestListDto
                        {
                            Id = manifest.Id,
                            ManifestRegistrationNumber = manifest.ManifestRegistrationNumber,
                            VoyageNo = manifest.VoyageNo,
                            NoticeNo = manifest.NoticeNo,
                            ShipAgent = manifest.ShipAgent,
                            VesselName = manifest.VesselName,
                            Imo = manifest.Imo,
                            ManifestNo = item.ManifestNo,
                            TrafficName = item.Traffic?.Name ?? string.Empty,
                            ConsigneeName = item.Consignee?.Name ?? string.Empty,
                            CargoTypeName = item.CargoType?.Name ?? string.Empty,
                            HSCode = good.Commodity?.HsCode ?? string.Empty,
                            CommodityName = good.Commodity?.Name ?? string.Empty,
                            PackageName = good.Package?.Name ?? string.Empty,
                            PackNb = good.PackNb,
                            GrossWeight = good.GrossWeight,
                            Container = string.Empty
                        });
                    }

                    foreach (var container in item.ManifestContainers)
                    {
                        result.Add(new ManifestListDto
                        {
                            Id = manifest.Id,
                            ManifestRegistrationNumber = manifest.ManifestRegistrationNumber,
                            VoyageNo = manifest.VoyageNo,
                            NoticeNo = manifest.NoticeNo,
                            ShipAgent = manifest.ShipAgent,
                            VesselName = manifest.VesselName,
                            Imo = manifest.Imo,
                            ManifestNo = item.ManifestNo,
                            TrafficName = item.Traffic?.Name ?? string.Empty,
                            ConsigneeName = item.Consignee?.Name ?? string.Empty,
                            CargoTypeName = item.CargoType?.Name ?? string.Empty,
                            CommodityName = "Container",
                            PackageName = "SX",
                            PackNb = container.ManifestContainerGoods.Sum(x => x.PackNb),
                            GrossWeight = container.ManifestContainerGoods.Sum(x => x.GrossWeight),
                            Container = container.Container?.No ?? string.Empty
                        });
                    }

                    if (item.ManifestGoods.Count == 0 && item.ManifestContainers.Count == 0)
                    {
                        result.Add(new ManifestListDto
                        {
                            Id = manifest.Id,
                            ManifestRegistrationNumber = manifest.ManifestRegistrationNumber,
                            VoyageNo = manifest.VoyageNo,
                            NoticeNo = manifest.NoticeNo,
                            ShipAgent = manifest.ShipAgent,
                            VesselName = manifest.VesselName,
                            Imo = manifest.Imo,
                            ManifestNo = item.ManifestNo,
                            TrafficName = item.Traffic?.Name ?? string.Empty,
                            ConsigneeName = item.Consignee?.Name ?? string.Empty,
                            CargoTypeName = item.CargoType?.Name ?? string.Empty,
                            Container = string.Empty
                        });
                    }
                }

                if (manifest.ManifestItems.Count == 0)
                {
                    result.Add(new ManifestListDto
                    {
                        Id = manifest.Id,
                        ManifestRegistrationNumber = manifest.ManifestRegistrationNumber,
                        VoyageNo = manifest.VoyageNo,
                        NoticeNo = manifest.NoticeNo,
                        ShipAgent = manifest.ShipAgent,
                        VesselName = manifest.VesselName,
                        Imo = manifest.Imo
                    });
                }
            }

            return new PagedResult<ManifestListDto>
            {
                Items = result,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };            
        }

        public async Task<List<ManifestItemLookupDto>> GetManifestItemsLookup(string terminalCode, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(x => x.TerminalCode == terminalCode)
                .SelectMany(x => x.ManifestItems.Select(item => new ManifestItemLookupDto
                {
                    Id = item.Id,
                    ManifestItemId = item.Id,
                    VoyageNo = x.VoyageNo,
                    ManifestNo = item.ManifestNo
                }))
                .OrderBy(x => x.VoyageNo)
                .ThenBy(x => x.ManifestNo)
                .ToListAsync(cancellationToken);
        }

        public async Task<ManifestItem?> GetManifestItemById(Guid itemId, CancellationToken cancellationToken = default)
        {
            var item = await _dbSet
                .AsNoTracking()
                .SelectMany(x => x.ManifestItems)
                .Where(x => x.Id == itemId)
                .Include(x => x.Manifest)
                .Include(x => x.Traffic)
                .Include(x => x.Consignee)
                .Include(x => x.ShipAgent)
                .Include(x => x.CargoType)
                .Include(x => x.ManifestGoods)
                    .ThenInclude(x => x.Commodity)
                .Include(x => x.ManifestGoods)
                    .ThenInclude(x => x.Package)
                .Include(x => x.ManifestContainers)
                    .ThenInclude(x => x.Container)
                        .ThenInclude(x => x.ContainerTypeAndSize)
                .Include(x => x.ManifestContainers)
                    .ThenInclude(x => x.ManifestContainerGoods)
                        .ThenInclude(x => x.Commodity)
                .Include(x => x.ManifestContainers)
                    .ThenInclude(x => x.ManifestContainerGoods)
                        .ThenInclude(x => x.Package)
                .FirstOrDefaultAsync(cancellationToken);

            if (item == null)
                return null;

            return item;
        }
    }
}
