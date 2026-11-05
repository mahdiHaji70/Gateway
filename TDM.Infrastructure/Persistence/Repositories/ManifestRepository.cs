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

        public async Task<PagedResult<ManifestListDto>> GetPagedManifests(
            int pageNumber, int pageSize, string terminalCode, string? search, DateTime? dateFrom, DateTime? dateTo,
            Guid? trafficId, Guid? consigneeId, Guid? cargoTypeId, Guid? commodityId, Guid? packageId)
        {
            IQueryable<Manifest> query = _dbSet.Where(x => x.TerminalCode == terminalCode).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim();
                query = query.Where(x => x.ManifestRegistrationNumber.Contains(term) || x.VoyageNo.Contains(term) ||
                    x.NoticeNo.Contains(term) || x.ShipAgent.Contains(term) || x.VesselName.Contains(term) || x.Imo.Contains(term) ||
                    x.ManifestItems.Any(i => i.ManifestNo.Contains(term) || i.ManifestItemNo.Contains(term)));
            }
            if (dateFrom.HasValue) query = query.Where(x => x.ETA >= dateFrom.Value.Date);
            if (dateTo.HasValue)
            {
                var endExclusive = dateTo.Value.Date.AddDays(1);
                query = query.Where(x => x.ETA < endExclusive);
            }
            if (trafficId.HasValue || consigneeId.HasValue || cargoTypeId.HasValue || commodityId.HasValue || packageId.HasValue)
            {
                query = query.Where(x => x.ManifestItems.Any(i =>
                    (!trafficId.HasValue || i.TrafficId == trafficId.Value) &&
                    (!consigneeId.HasValue || i.ConsigneeId == consigneeId.Value) &&
                    (!cargoTypeId.HasValue || i.CargoTypeId == cargoTypeId.Value) &&
                    (!commodityId.HasValue || i.ManifestGoods.Any(g => g.CommodityId == commodityId.Value) ||
                        i.ManifestContainers.Any(c => c.ManifestContainerGoods.Any(g => g.CommodityId == commodityId.Value))) &&
                    (!packageId.HasValue || i.ManifestGoods.Any(g => g.PackageId == packageId.Value) ||
                        i.ManifestContainers.Any(c => c.ManifestContainerGoods.Any(g => g.PackageId == packageId.Value)))));
            }

            var manifests = await query
                .OrderByDescending(x => x.CreatedAt)
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
                            .ThenInclude(x => x.Commodity)
                .Include(x => x.ManifestItems)
                    .ThenInclude(x => x.ManifestContainers)
                        .ThenInclude(x => x.ManifestContainerGoods)
                            .ThenInclude(x => x.Package)
                .ToListAsync();

            var result = new List<ManifestListDto>();

            foreach (var manifest in manifests)
            {
                var manifestItems = manifest.ManifestItems.AsEnumerable();
                if (trafficId.HasValue) manifestItems = manifestItems.Where(x => x.TrafficId == trafficId.Value);
                if (consigneeId.HasValue) manifestItems = manifestItems.Where(x => x.ConsigneeId == consigneeId.Value);
                if (cargoTypeId.HasValue) manifestItems = manifestItems.Where(x => x.CargoTypeId == cargoTypeId.Value);
                if (commodityId.HasValue) manifestItems = manifestItems.Where(x =>
                    x.ManifestGoods.Any(g => g.CommodityId == commodityId.Value) ||
                    x.ManifestContainers.Any(c => c.ManifestContainerGoods.Any(g => g.CommodityId == commodityId.Value)));
                if (packageId.HasValue) manifestItems = manifestItems.Where(x =>
                    x.ManifestGoods.Any(g => g.PackageId == packageId.Value) ||
                    x.ManifestContainers.Any(c => c.ManifestContainerGoods.Any(g => g.PackageId == packageId.Value)));
                if (!string.IsNullOrWhiteSpace(search))
                {
                    var term = search.Trim();
                    var parentMatches = manifest.ManifestRegistrationNumber.Contains(term) || manifest.VoyageNo.Contains(term) ||
                        manifest.NoticeNo.Contains(term) || manifest.ShipAgent.Contains(term) || manifest.VesselName.Contains(term) || manifest.Imo.Contains(term);
                    if (!parentMatches)
                        manifestItems = manifestItems.Where(x => x.ManifestNo.Contains(term) || x.ManifestItemNo.Contains(term) ||
                            (x.Traffic != null && x.Traffic.Name.Contains(term)) ||
                            (x.Consignee != null && x.Consignee.Name.Contains(term)) ||
                            (x.CargoType != null && x.CargoType.Name.Contains(term)) ||
                            x.ManifestGoods.Any(g => (g.Commodity != null && (g.Commodity.HsCode.Contains(term) || g.Commodity.Name.Contains(term))) ||
                                (g.Package != null && g.Package.Name.Contains(term))) ||
                            x.ManifestContainers.Any(c => (c.Container != null && c.Container.No.Contains(term)) ||
                                c.ManifestContainerGoods.Any(g => (g.Commodity != null && (g.Commodity.HsCode.Contains(term) || g.Commodity.Name.Contains(term))) ||
                                    (g.Package != null && g.Package.Name.Contains(term)))));
                }

                var filteredItems = manifestItems.ToList();
                foreach (var item in filteredItems)
                {
                    var goods = item.ManifestGoods.AsEnumerable();
                    if (commodityId.HasValue) goods = goods.Where(x => x.CommodityId == commodityId.Value);
                    if (packageId.HasValue) goods = goods.Where(x => x.PackageId == packageId.Value);
                    if (!string.IsNullOrWhiteSpace(search))
                    {
                        var term = search.Trim();
                        var parentMatches = manifest.ManifestRegistrationNumber.Contains(term) || manifest.VoyageNo.Contains(term) ||
                            manifest.NoticeNo.Contains(term) || manifest.ShipAgent.Contains(term) || manifest.VesselName.Contains(term) || manifest.Imo.Contains(term) ||
                            item.ManifestNo.Contains(term) || item.ManifestItemNo.Contains(term) ||
                            (item.Traffic != null && item.Traffic.Name.Contains(term)) ||
                            (item.Consignee != null && item.Consignee.Name.Contains(term)) ||
                            (item.CargoType != null && item.CargoType.Name.Contains(term));
                        if (!parentMatches)
                            goods = goods.Where(x => (x.Commodity != null && (x.Commodity.HsCode.Contains(term) || x.Commodity.Name.Contains(term))) ||
                                (x.Package != null && x.Package.Name.Contains(term)));
                    }
                    var filteredGoods = goods.ToList();

                    foreach (var good in filteredGoods)
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
                        var parentSearchMatches = string.IsNullOrWhiteSpace(search) ||
                            manifest.ManifestRegistrationNumber.Contains(search.Trim()) || manifest.VoyageNo.Contains(search.Trim()) ||
                            manifest.NoticeNo.Contains(search.Trim()) || manifest.ShipAgent.Contains(search.Trim()) ||
                            manifest.VesselName.Contains(search.Trim()) || manifest.Imo.Contains(search.Trim()) ||
                            item.ManifestNo.Contains(search.Trim()) || item.ManifestItemNo.Contains(search.Trim()) ||
                            (item.Traffic != null && item.Traffic.Name.Contains(search.Trim())) ||
                            (item.Consignee != null && item.Consignee.Name.Contains(search.Trim())) ||
                            (item.CargoType != null && item.CargoType.Name.Contains(search.Trim()));
                        var containerSearchMatches = !string.IsNullOrWhiteSpace(search) &&
                            container.Container?.No.Contains(search.Trim(), StringComparison.OrdinalIgnoreCase) == true;
                        var containerGoods = container.ManifestContainerGoods.AsEnumerable();
                        if (commodityId.HasValue) containerGoods = containerGoods.Where(x => x.CommodityId == commodityId.Value);
                        if (packageId.HasValue) containerGoods = containerGoods.Where(x => x.PackageId == packageId.Value);
                        if (!string.IsNullOrWhiteSpace(search))
                        {
                            var term = search.Trim();
                            if (!parentSearchMatches && !containerSearchMatches)
                                containerGoods = containerGoods.Where(x => (x.Commodity != null && (x.Commodity.HsCode.Contains(term) || x.Commodity.Name.Contains(term))) ||
                                    (x.Package != null && x.Package.Name.Contains(term)));
                        }
                        var filteredContainerGoods = containerGoods.ToList();
                        if ((commodityId.HasValue || packageId.HasValue) && filteredContainerGoods.Count == 0)
                            continue;
                        if (!parentSearchMatches && !containerSearchMatches && !string.IsNullOrWhiteSpace(search) && filteredContainerGoods.Count == 0)
                            continue;

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
                            PackNb = filteredContainerGoods.Sum(x => x.PackNb),
                            GrossWeight = filteredContainerGoods.Sum(x => x.GrossWeight),
                            Container = container.Container?.No ?? string.Empty
                        });
                    }

                    if (filteredGoods.Count == 0 && item.ManifestContainers.Count == 0 && !commodityId.HasValue && !packageId.HasValue &&
                        string.IsNullOrWhiteSpace(search))
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

                if (filteredItems.Count == 0 && manifest.ManifestItems.Count == 0 && string.IsNullOrWhiteSpace(search) &&
                    !trafficId.HasValue && !consigneeId.HasValue && !cargoTypeId.HasValue && !commodityId.HasValue && !packageId.HasValue)
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

            var totalCount = result.Count;
            var pagedResult = result
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResult<ManifestListDto>
            {
                Items = pagedResult,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };            
        }

        public async Task<List<ManifestItemLookupDto>> GetManifestItemsLookup(string terminalCode, string? search, CancellationToken cancellationToken = default)
        {
            var query = _dbSet
                .AsNoTracking()
                .Where(x => x.TerminalCode == terminalCode)
                .SelectMany(x => x.ManifestItems.Select(item => new ManifestItemLookupDto
                {
                    Id = item.Id,
                    ManifestItemId = item.Id,
                    VoyageNo = x.VoyageNo,
                    ManifestNo = item.ManifestNo,
                    IpasItemId = item.IpasItemId
                }));

            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchTerm = search.Trim();
                query = query.Where(x =>
                    x.VoyageNo.Contains(searchTerm) ||
                    x.ManifestNo.Contains(searchTerm));
            }

            return await query
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
