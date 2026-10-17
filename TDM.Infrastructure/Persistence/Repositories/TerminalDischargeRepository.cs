using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Application.Operation.TerminalDischarges.DTOs;
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
           .Include(x => x.DeclarationItem)
           .ThenInclude(x => x.Declaration);
          
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
                        .Include(x => x.DeclarationItem)
                        .ThenInclude(x => x.Declaration)
                        .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<TerminalDischarge>?> GetByDeclarationIdAsync(Guid id)
        {
            return await _dbSet
                        .AsNoTracking()
                        .Include(x => x.Store)
                        .Include(x => x.DeclarationItem)
                        .Where(x => x.DeclarationItem.DeclarationId == id).ToListAsync();
        }

        public async Task<List<TerminalDischarge>> GetByIssueRequestIdAsync(Guid issueRequestId)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(x => x.Store)
                .Include(x => x.DeclarationItem)
                    .ThenInclude(x => x.Commodity)
                .Include(x => x.DeclarationItem)
                    .ThenInclude(x => x.Package)
                .Where(x => x.IssueRequestId == issueRequestId)
                .ToListAsync();
        }
        public async Task<List<TerminalDischarge>> GetPendingIpasSubmissionByDeclarationIdAsync(Guid declarationId)
        {
            return await _dbSet
                       .Include(x => x.Store)
                       .Include(x => x.DeclarationItem)
                       .Include(x => x.DeclarationItem.Declaration)
                       .Include(x => x.DeclarationItem.Commodity)
                       .Include(x => x.DeclarationItem.Package)
                       .Where(x => x.DeclarationItem.DeclarationId == declarationId
                                && x.IpasTerminalDischargeId == null)
                       .ToListAsync();
        }

        public async Task<PagedResult<TerminalDischarge>?> GetTerminalDischargesByDeclarationIdPagedAsync(
            Guid declarationId, int pageNumber, int pageSize)
        {
            var query = _dbSet
           .AsNoTracking()
           .Include(x => x.Store)
           .Include(x => x.DeclarationItem)
           .ThenInclude(x => x.Declaration)
           .Where(x => x.DeclarationItem.Declaration.Id == declarationId);


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
        public async Task<List<TerminalDischarge>> GetIpasSubmissionByIPASDeclarationNoAsync(string ipasDeclarationNo)
        {
            return await _dbSet
                       .Include(x => x.DeclarationItem)
                       .Include(x => x.DeclarationItem.Declaration)
                       .Include(x => x.DeclarationItem.Commodity)
                       .Include(x => x.DeclarationItem.Package)
                       .Where(x => x.DeclarationItem.Declaration.IpasDeclarationNo == ipasDeclarationNo
                                && x.IpasTerminalDischargeId == null)
                       .ToListAsync();
        }

        public async Task<List<GroupedTerminalDischargeDto>> GetGroupedAsync(
            Guid declarationId,
            Guid? issueRequestId,
            CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(x => x.DeclarationItem.DeclarationId == declarationId
                    && (!issueRequestId.HasValue || x.IssueRequestId == issueRequestId)
                    && x.IpasTerminalDischargeId != null)
                .GroupBy(x => new
                {
                    DeclarationId = x.DeclarationItem.DeclarationId,
                    IpasDeclarationNo = x.DeclarationItem.Declaration.IpasDeclarationNo,
                    x.TerminalCode,
                    CargoTypeId = x.DeclarationItem.CargoTypeId,
                    CargoTypeName = x.DeclarationItem.CargoType.Name,
                    x.StoreId,
                    StoreName = x.Store.Name,
                    x.DeclarationItemId,
                    x.WayBillNo,
                    x.WayBillId,
                    x.DischargeDate,
                    x.IsNonPalletized,
                    x.IsDamaged,
                    x.IsVoluminous,
                    x.IsDangerous,
                    x.DangerousCode,
                    x.Classification,
                    x.IgnitionTemperature,
                    x.IgnitionTemperatureUnit,
                    x.IpasTerminalDischargeId,
                    x.IpasTerminalDischargeReceivedAt
                })
                .Select(group => new GroupedTerminalDischargeDto
                {
                    DeclarationId = group.Key.DeclarationId,
                    IpasDeclarationNo = group.Key.IpasDeclarationNo,
                    TerminalCode = group.Key.TerminalCode,
                    CargoTypeId = group.Key.CargoTypeId,
                    CargoTypeName = group.Key.CargoTypeName,
                    StoreId = group.Key.StoreId,
                    StoreName = group.Key.StoreName,
                    DeclarationItemId = group.Key.DeclarationItemId,
                    WayBillNo = group.Key.WayBillNo,
                    WayBillId = group.Key.WayBillId,
                    DischargeDate = group.Key.DischargeDate,
                    PackNB = group.Sum(x => x.PackNB),
                    Weight = group.Sum(x => x.Weight),
                    Volume = group.Sum(x => x.Volume),
                    IsNonPalletized = group.Key.IsNonPalletized,
                    IsDamaged = group.Key.IsDamaged,
                    IsVoluminous = group.Key.IsVoluminous,
                    IsDangerous = group.Key.IsDangerous,
                    DangerousCode = group.Key.DangerousCode,
                    Classification = group.Key.Classification,
                    IgnitionTemperature = group.Key.IgnitionTemperature,
                    IgnitionTemperatureUnit = group.Key.IgnitionTemperatureUnit,
                    IpasTerminalDischargeId = group.Key.IpasTerminalDischargeId,
                    IpasTerminalDischargeReceivedAt = group.Key.IpasTerminalDischargeReceivedAt,
                    IsSend = group.Key.IpasTerminalDischargeId != null
                })
                .ToListAsync(cancellationToken);
        }

    }
}
