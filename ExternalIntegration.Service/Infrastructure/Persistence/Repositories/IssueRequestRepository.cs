using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Repositories
{
    public class IssueRequestRepository : Repository<IssueRequest>, IIssueRequestRepository
    {
        protected readonly DbSet<IssueRequest> _IssueRequestDbSet;

        public IssueRequestRepository(GatewayDbContext context) : base(context)
        {
            _IssueRequestDbSet = _context.Set<IssueRequest>();
        }

        public async Task<DateTime> GetLastDateAsync(string terminalCode)
        {
            return await _IssueRequestDbSet
                .Where(x => x.TerminalCode == terminalCode)
                .OrderByDescending(x => x.Date).Select(x => x.Date).FirstOrDefaultAsync();
        }
        public async Task<List<IssueRequest>> GetByStorageAgreementNoAsync(string storageAgreementNo)
        {
            return await _IssueRequestDbSet
                .AsNoTracking()
                .Where(t => t.StorageAgreementNo == storageAgreementNo &&
                              t.IsApproved == false).ToListAsync();
        }
        public async void UpdateIssueRequestApprovalAsync(Guid requestId, bool IsApproved)
        {
            var record = _IssueRequestDbSet.FirstOrDefault(t => t.RequestId == requestId);
            record.IsApproved = IsApproved;
            var result = await _context.SaveChangesAsync();
      
        }

        public  async Task<List<IssueRequest>> GetByIdNoAsync(Guid id)
        {
            return await _IssueRequestDbSet
                .AsNoTracking()
                .Where(t => t.RequestId == id &&
                              t.IsApproved == true).ToListAsync();
        }
    }
}
