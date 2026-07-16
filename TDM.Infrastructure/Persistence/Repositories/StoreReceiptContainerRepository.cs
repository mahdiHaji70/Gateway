using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class StoreReceiptContainerRepository : Repository<StoreReceiptContainer>, IStoreReceiptContainerRepository
    {
        public StoreReceiptContainerRepository(TDMDbContext context) : base(context)
        {

        }


        public async override Task<PagedResult<StoreReceiptContainer>?> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _dbSet
           .AsNoTracking()
           .Include(x => x.Container)
           .Include(x => x.StoreReceiptHead);


            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<StoreReceiptContainer>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async override Task<StoreReceiptContainer?> GetAsync(Guid id)
        {
            return await _dbSet
                       .AsNoTracking()
                       .Include(x => x.Container)
                       .Include(x => x.StoreReceiptHead)
                       .FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
