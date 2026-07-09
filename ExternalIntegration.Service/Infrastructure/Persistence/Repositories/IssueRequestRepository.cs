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
       
        public async Task<DateTime> GetLastDateAsync()
        {
            return await _IssueRequestDbSet.OrderByDescending(x => x.Date).Select(x => x.Date).FirstOrDefaultAsync();
        }
    }
}
