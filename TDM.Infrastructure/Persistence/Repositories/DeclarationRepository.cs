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

        public async Task<PagedResult<Declaration>?> GetPagedDeclarationsAsync(
            int pageNumber,
            int pageSize,
            string? search,
            Guid? trafficId,
            Guid? consigneeId,
            Guid? consigneeRepId,
            DateTime? dateFrom,
            DateTime? dateTo)
        {
            IQueryable<Declaration> query = _dbSet
                .AsNoTracking()
                .Include(x => x.Consignee)
                .Include(x => x.ConsigneeRep)
                .Include(x => x.Traffic);

            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchTerm = search.Trim();
                query = query.Where(x =>
                    x.Number.Contains(searchTerm) ||
                    (x.IpasDeclarationNo != null && x.IpasDeclarationNo.Contains(searchTerm)));
            }

            if (trafficId.HasValue)
                query = query.Where(x => x.TrafficId == trafficId.Value);

            if (consigneeId.HasValue)
                query = query.Where(x => x.ConsigneeId == consigneeId.Value);

            if (consigneeRepId.HasValue)
                query = query.Where(x => x.ConsigneeRepId == consigneeRepId.Value);

            if (dateFrom.HasValue)
                query = query.Where(x => x.Date >= dateFrom.Value.Date);

            if (dateTo.HasValue)
            {
                var exclusiveDateTo = dateTo.Value.Date.AddDays(1);
                query = query.Where(x => x.Date < exclusiveDateTo);
            }

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

        public async Task<PagedResult<Declaration>?> GetLookupAsync(string? search, int pageNumber, int pageSize)
        {
            var query = _dbSet
                .AsNoTracking()
                .Where(x => x.IpasDeclarationNo != null && x.IpasDeclarationNo != string.Empty);

            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchTerm = search.Trim();
                query = query.Where(x => x.IpasDeclarationNo!.Contains(searchTerm));
            }

            var totalCount = await query.CountAsync();
            var items = await query
                .OrderBy(x => x.IpasDeclarationNo)
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
   
       public bool ExistsByIpasDeclarationNo(string IpasDeclarationNo)
        {
            return _dbSet.Any(x => x.IpasDeclarationNo.Contains(IpasDeclarationNo));
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
