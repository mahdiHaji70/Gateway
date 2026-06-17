using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class TerminalDischargeRepository : Repository<TerminalDischarge>, ITerminalDischargeRepository
    {
        public TerminalDischargeRepository(TDMDbContext context) : base(context)
        {
        }

        public async override Task<PagedResult<TerminalDischarge>?> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _dbSet
           .AsNoTracking()
           .Include(x => x.Store)
           .Include(x=>x.CargoType);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<TerminalDischarge>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async override Task<TerminalDischarge?> GetAsync(Guid id)
        {
            return await _dbSet
                        .AsNoTracking()
                        .Include(x => x.Store)
                        .Include(x => x.CargoType)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
