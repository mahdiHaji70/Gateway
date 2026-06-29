using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Repositories
{
    public class GoodwayBillRepository : Repository<GoodwayBill>, IGoodwayBillRepository
    {
        protected readonly DbSet<GoodwayBill> _goodwayBillDbSet;

        public GoodwayBillRepository(GatewayDbContext context) : base(context) 
        {
            _goodwayBillDbSet = _context.Set<GoodwayBill>();
        }
        public async Task<List<GoodwayBill>> GetByStorageAgreementIdAsync(GetGoodwayBillDto dto)
        {
            return await _goodwayBillDbSet
                .AsNoTracking()
                .Where(t => t.StorageAgreementId == dto.storageAgreementId && 
                             t.TerminalCode ==dto.TerminalCode).ToListAsync(); 
        }

        public async Task<DateTime> GetLastDateAsync()
        {
            return await _goodwayBillDbSet.OrderByDescending(x => x.Date).Select(x => x.Date).FirstOrDefaultAsync();
        }
    }
}
