using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Application.DTOs;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Repositories
{
    public class ManifestRepository : Repository<Manifest>, IManifestRepository
    {
        protected readonly DbSet<Manifest> _manifestDbSet;

        public ManifestRepository(GatewayDbContext context) : base(context)
        {
            _manifestDbSet = _context.Set<Manifest>();
        }

        public async Task<DateTime> GetLastDateAsync(string terminalCode)
        {
            return await _manifestDbSet
                .Where(x => x.TerminalCodeDischarge == terminalCode)
                .OrderByDescending(x => x.CreationDate).Select(x => x.CreationDate).FirstOrDefaultAsync();
        }
        
        public async Task<IEnumerable<ManifestNoticeToApproveDto>> GetManifestsNoticeNoToApprove(string terminalCode)
        {
            return await _manifestDbSet
               .AsNoTracking()
               .Where(x => x.TerminalCodeDischarge == terminalCode && !x.IsApproved)
                .Select(x => new ManifestNoticeToApproveDto
                {
                      Id = x.Id,
                      NoticeNo = x.NoticeNo
                })
                .ToListAsync();
        }

        public async Task<Manifest?> GetManifestById(Guid id)
        {
            return await _manifestDbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> ApproveManifestAsync(Guid id)
        {
            var manifest = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (manifest == null)
                return false;

            manifest.IsApproved = true;
            _dbSet.Update(manifest);

            return true;
        }
    }
}
