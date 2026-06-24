using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Repositories
{
    public class GoodwayBillRepository : Repository<GoodwayBill>, IGoodwayBillRepository
    {
        public GoodwayBillRepository(GatewayDbContext context) : base(context) { }
        public async Task<List<GoodwayBill?>> GetByStorageAgreementIdAsync(GetGoodwayBillDto dto)
        {
            return await _context.GoodwayBills
                .AsNoTracking()
                .Where(t => t.StorageAgreementId == dto.storageAgreementId && 
                             t.TerminalCode ==dto.TerminalCode).ToListAsync(); 
        }
    }
}
