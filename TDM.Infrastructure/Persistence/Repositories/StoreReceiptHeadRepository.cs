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
           .Include(x => x.Declaration);

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
