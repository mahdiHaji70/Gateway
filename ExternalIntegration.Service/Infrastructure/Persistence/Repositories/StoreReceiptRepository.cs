using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Repositories
{
    public class StoreReceiptRepository : Repository<StoreReceipt>, IStoreReceiptRepository
    {
        protected readonly DbSet<StoreReceipt> _StoreReceiptDbSet;

        public StoreReceiptRepository(GatewayDbContext context) : base(context)
        {
            _StoreReceiptDbSet = _context.Set<StoreReceipt>();
        }
       
        public async Task<DateTime> GetLastDateAsync()
        {
            return await _StoreReceiptDbSet.OrderByDescending(x => x.Date).Select(x => x.Date).FirstOrDefaultAsync();
        }
    }
}
