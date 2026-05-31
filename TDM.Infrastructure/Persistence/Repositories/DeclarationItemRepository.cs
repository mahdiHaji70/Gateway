using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class DeclarationItemRepository : Repository<DeclarationItem>, IDeclarationItemRepository
    {
        public DeclarationItemRepository(TDMDbContext context) : base(context)
        {
        }

        public async override Task<PagedResult<DeclarationItem>?> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _dbSet
           .AsNoTracking()
           .Include(x => x.Declaration)
           .Include(x => x.Commodity)
           .Include(x => x.Package);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<DeclarationItem>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async override Task<DeclarationItem?> GetAsync(Guid id)
        {
            return await _dbSet
                        .AsNoTracking()
                        .Include(x => x.Declaration)
                        .Include(x => x.Commodity)
                        .Include(x => x.Package)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
