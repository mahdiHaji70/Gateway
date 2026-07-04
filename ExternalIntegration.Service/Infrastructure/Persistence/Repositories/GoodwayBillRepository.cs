using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<List<GoodwayBill>> GetByStorageAgreementIdAsync(Guid storageAgreementId, string terminalCode)
        {
            return await _goodwayBillDbSet
                .AsNoTracking()
                .Where(t => t.StorageAgreementId == storageAgreementId &&
                             t.TerminalCode == terminalCode).ToListAsync();
        }

        public async Task<DateTime> GetLastDateAsync()
        {
            return await _goodwayBillDbSet.OrderByDescending(x => x.Date).Select(x => x.Date).FirstOrDefaultAsync();
        }
    }
}
