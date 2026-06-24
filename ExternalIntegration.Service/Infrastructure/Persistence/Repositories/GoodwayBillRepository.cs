using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Repositories
{
    public class GoodwayBillRepository : Repository<GoodwayBill>, IGoodwayBillRepository
    {
        public GoodwayBillRepository(GatewayDbContext context) : base(context) { }
        public async Task<List<GoodwayBill?>> GetByStorageAgreementIdAsync(Guid storageAgreementId)
        {
            return await _context.GoodwayBills
                .AsNoTracking()
                .Where(t => t.StorageAgreementId == storageAgreementId).ToListAsync(); 
        }
    }
}
