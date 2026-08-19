using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Application.DTOs;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public override async Task<List<Manifest>> FilterUnpersistedAsync<TId>(
     IEnumerable<Manifest> entities,
     Func<Manifest, TId> idSelector,
     Expression<Func<Manifest, TId>> dbIdSelector)
        {
            var entityList = entities.ToList();
            if (!entityList.Any())
                return new List<Manifest>();

            if (dbIdSelector.Body is not MemberExpression memberExpr)
            {
                throw new ArgumentException("dbIdSelector must be a simple member expression.", nameof(dbIdSelector));
            }
            string propertyName = memberExpr.Member.Name;

            var incomingDict = entityList.ToDictionary(idSelector);
            var incomingIds = incomingDict.Keys.ToList();

            var existingRecords = await _dbSet
                .Where(e => incomingIds.Contains(EF.Property<TId>(e, propertyName)))
                .Select(e => new
                {
                    Entity = e,
                    Id = EF.Property<TId>(e, propertyName),
                    e.Signed
                })
                .ToListAsync();

            var existingDict = existingRecords.ToDictionary(x => x.Id, x => x);
            var resultsToInsert = new List<Manifest>();

            foreach (var incoming in entityList)
            {
                var id = idSelector(incoming);

                if (existingDict.TryGetValue(id, out var existing))
                {
                    if (incoming.Signed && !existing.Signed)
                    {
                        _dbSet.Remove(existing.Entity);
                        resultsToInsert.Add(incoming);
                    }
                }
                else
                    resultsToInsert.Add(incoming);                
            }

            return resultsToInsert;
        }

    }
}
