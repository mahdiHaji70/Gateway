using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class StoreReceiptHeadRepository : Repository<StoreReceiptHead>, IStoreReceiptHeadRepository
    {
        public StoreReceiptHeadRepository(TDMDbContext context) : base(context)
        {

        }


        public async override Task<PagedResult<StoreReceiptHead>?> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _dbSet
           .AsNoTracking()
           .Include(x => x.Consignee)
           .Include(x => x.ArrivalType)
           .Include(x => x.StoreReceiptState)
           .Include(x => x.CargoType)
           .Include(x => x.Traffic)
           .Include(x => x.Declaration)
           .Include(x => x.ManifestItem);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<StoreReceiptHead>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<PagedResult<StoreReceiptHead>?> GetPagedFilteredAsync(
            int pageNumber, int pageSize, string? search, DateTime? dateFrom, DateTime? dateTo,
            Guid? consigneeId, Guid? consigneeRepId, Guid? trafficId, Guid? cargoTypeId, string? arrivalTypeCode)
        {
            IQueryable<StoreReceiptHead> query = _dbSet.AsNoTracking()
                .Include(x => x.Consignee)
                .Include(x => x.ConsigneeRep)
                .Include(x => x.ArrivalType)
                .Include(x => x.StoreReceiptState)
                .Include(x => x.CargoType)
                .Include(x => x.Traffic)
                .Include(x => x.Declaration)
                .Include(x => x.ManifestItem);

            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim();
                query = query.Where(x => x.IPASStoreReceiptNo.Contains(term) ||
                    x.VoyageNoticeNo.Contains(term) ||
                    (x.Declaration != null && x.Declaration.IpasDeclarationNo != null && x.Declaration.IpasDeclarationNo.Contains(term)) ||
                    (x.ManifestItem != null && x.ManifestItem.ManifestNo.Contains(term)));
            }
            if (dateFrom.HasValue) query = query.Where(x => x.IssueDate >= dateFrom.Value.Date);
            if (dateTo.HasValue)
            {
                var endExclusive = dateTo.Value.Date.AddDays(1);
                query = query.Where(x => x.IssueDate < endExclusive);
            }
            if (consigneeId.HasValue) query = query.Where(x => x.ConsigneeId == consigneeId.Value);
            if (consigneeRepId.HasValue) query = query.Where(x => x.ConsigneeRepId == consigneeRepId.Value);
            if (trafficId.HasValue) query = query.Where(x => x.TrafficId == trafficId.Value);
            if (cargoTypeId.HasValue) query = query.Where(x => x.CargoTypeId == cargoTypeId.Value);
            if (!string.IsNullOrWhiteSpace(arrivalTypeCode))
                query = query.Where(x => x.ArrivalType.Code == arrivalTypeCode);

            var totalCount = await query.CountAsync();
            var items = await query.OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PagedResult<StoreReceiptHead>
            { Items = items, TotalCount = totalCount, PageNumber = pageNumber, PageSize = pageSize };
        }

        public async override Task<StoreReceiptHead?> GetAsync(Guid id)
        {
            return await _dbSet
                        .AsNoTracking()
                        .Include(x => x.Consignee)
                       .Include(x => x.ArrivalType)
                       .Include(x => x.StoreReceiptState)
                       .Include(x => x.CargoType)
                       .Include(x => x.Traffic)
                       .Include(x => x.Declaration)
                       .Include(x => x.ManifestItem)
                       .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<StoreReceiptHead?> GetForAllocationAsync(Guid id)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(x => x.StoreReceiptGoods).ThenInclude(x => x.Commodity)
                .Include(x => x.StoreReceiptGoods).ThenInclude(x => x.Package)
                .Include(x => x.StoreReceiptContainers).ThenInclude(x => x.Container)
                .Include(x => x.StoreReceiptContainers).ThenInclude(x => x.StoreReceiptContainerGoods).ThenInclude(x => x.Commodity)
                .Include(x => x.StoreReceiptContainers).ThenInclude(x => x.StoreReceiptContainerGoods).ThenInclude(x => x.Package)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
