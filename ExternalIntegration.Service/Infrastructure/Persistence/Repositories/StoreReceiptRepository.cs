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
        protected readonly DbSet<StoreReceipt> _storeReceiptDbSet;
        protected readonly DbSet<IssueRequest> _issueRequestDbSet;

        public StoreReceiptRepository(GatewayDbContext context) : base(context)
        {
            _storeReceiptDbSet = _context.Set<StoreReceipt>();
            _issueRequestDbSet = _context.Set<IssueRequest>();
        }

        public async Task<DateTime> GetLastDateAsync()
        {
            return await _storeReceiptDbSet.OrderByDescending(x => x.Date).Select(x => x.Date).FirstOrDefaultAsync();
        }
        public async Task<List<StoreReceipt>> GetByStorageAgreementNoAsync(string storageAgreementNo)
        {
            var query = from issueRequest in _issueRequestDbSet
                        join storeReceipt in _storeReceiptDbSet
                        on issueRequest.RequestId equals storeReceipt.RequestId
                        where issueRequest.StorageAgreementNo == storageAgreementNo
                        select storeReceipt;

             return await  query.ToListAsync();
        }
        public async Task<StoreReceipt> GetByNoAsync(string no)
        {
            return await _storeReceiptDbSet
                        .AsNoTracking()
                       .FirstOrDefaultAsync(t => t.No == no);

        }
    }    
}
