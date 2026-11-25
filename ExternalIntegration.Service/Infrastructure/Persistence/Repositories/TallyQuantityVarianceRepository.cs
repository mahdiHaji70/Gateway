using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Repositories
{
    public class TallyQuantityVarianceRepository : Repository<TallyQuantityVariance>, ITallyQuantityVarianceRepository
    {
        public TallyQuantityVarianceRepository(GatewayDbContext context) : base(context) { }

        public override async Task<List<TallyQuantityVariance>> FilterUnpersistedAsync<TId>(
            IEnumerable<TallyQuantityVariance> entities,
            Func<TallyQuantityVariance, TId> idSelector,
            Expression<Func<TallyQuantityVariance, TId>> dbIdSelector)
        {
            var incoming = entities.GroupBy(x => x.Id).Select(x => x.Last()).ToList();
            var ids = incoming.Select(x => x.Id).ToList();
            var existing = await _dbSet.Where(x => ids.Contains(x.Id)).ToDictionaryAsync(x => x.Id);
            var newData = new List<TallyQuantityVariance>();
            foreach (var item in incoming)
            {
                if (existing.TryGetValue(item.Id, out var record))
                    _context.Entry(record).CurrentValues.SetValues(item);
                else
                    newData.Add(item);
            }
            return newData;
        }
    }
}
