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
        public async Task UpdateIssueRequestApprovalAsync(Guid requestId, bool isApproved)
        {
            var record = await _IssueRequestDbSet.FirstOrDefaultAsync(t => t.RequestId == requestId);
            record.IsApproved = isApproved;
            _IssueRequestDbSet.Update(record);
        }

        public async Task<IssueRequest?> GetByRequestIdAsync(Guid requestId, CancellationToken cancellationToken = default)
        {
            return await _IssueRequestDbSet.AsNoTracking()
                .FirstOrDefaultAsync(t => t.RequestId == requestId, cancellationToken);
        }

        public async Task<List<IssueRequest>> GetByIdNoAsync(Guid id)
        {
            return await _IssueRequestDbSet
                .AsNoTracking()
                .Where(t => t.RequestId == id &&
                              t.IsApproved == true).ToListAsync();
        }
    }
}
