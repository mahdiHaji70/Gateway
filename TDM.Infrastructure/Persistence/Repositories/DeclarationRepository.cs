using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class DeclarationRepository : Repository<Declaration>, IDeclarationRepository
    {
        public DeclarationRepository(TDMDbContext context) : base(context)
        {
        }

        public async override Task<PagedResult<Declaration>?> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _dbSet
           .AsNoTracking()
           .Include(x => x.Consignee)
           .Include(x => x.ConsigneeRep)
           .Include(x => x.Traffic);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Declaration>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async override Task<Declaration?> GetAsync(Guid id)
        {
            return await _dbSet
                        .AsNoTracking()
                        .Include(x => x.Consignee)
                        .Include(x => x.ConsigneeRep)
                        .Include(x => x.Traffic)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }
   
       public async Task<bool> ExistsByIpasDeclarationNo(string IpasDeclarationNo)
        {
            return await _dbSet.AnyAsync(x => x.IpasDeclarationNo .Contains( IpasDeclarationNo));
        }
        public async  Task<Declaration?> GetByIpasDeclarationNoAsync(string ipasDeclarationNo)
        {
            return await _dbSet
                        .AsNoTracking()
                        .Include(x => x.Consignee)
                        .Include(x => x.ConsigneeRep)
                        .Include(x => x.Traffic)
                        .FirstOrDefaultAsync(x => x.IpasDeclarationNo == ipasDeclarationNo);
        }
    }
 }