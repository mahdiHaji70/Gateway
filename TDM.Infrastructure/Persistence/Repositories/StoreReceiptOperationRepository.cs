using Microsoft.EntityFrameworkCore;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;
using TDM.Domain.Enums;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class StoreReceiptOperationRepository : Repository<StoreReceiptOperation>, IStoreReceiptOperationRepository
    {
        public StoreReceiptOperationRepository(TDMDbContext context) : base(context)
        {
        }

        public async Task<StoreReceiptOperation?> GetEarliestDischargeOperationAsync(
            Guid storeReceiptId,
            CancellationToken cancellationToken = default)
        {
            var operationTypeCode = OperationTypeCode.PRT.ToString();
            var serviceCode = ServiceCode.DIS.ToString();

            return await _dbSet
                .AsNoTracking()
                .Where(x => x.StoreReceiptHeadId == storeReceiptId
                    && x.OperationType.Code == operationTypeCode
                    && x.Service.Code == serviceCode)
                .OrderBy(x => x.Date)
                .ThenBy(x => x.Id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async override Task<PagedResult<StoreReceiptOperation>?> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _dbSet
                .AsNoTracking()
                .Include(x => x.StoreReceiptHead)
                .Include(x => x.StoreReceiptContainer)
                .Include(x => x.OperationType)
                .Include(x => x.Service)
                .Include(x => x.Store);

            var totalCount = await query.CountAsync();
            var items = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<StoreReceiptOperation>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async override Task<StoreReceiptOperation?> GetAsync(Guid id)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(x => x.StoreReceiptHead)
                .Include(x => x.StoreReceiptContainer)
                .Include(x => x.OperationType)
                .Include(x => x.Service)
                .Include(x => x.Store)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
