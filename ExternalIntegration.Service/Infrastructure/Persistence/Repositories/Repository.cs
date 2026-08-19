using ExternalIntegration.Service.Application.Abstractions;
using ExternalIntegration.Service.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace ExternalIntegration.Service.Infrastructure.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly GatewayDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;        

        public Repository(GatewayDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }        

        public async Task<TEntity?> GetAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task InsertBulkAsync(List<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async virtual Task<List<TEntity>> FilterUnpersistedAsync<TId>(IEnumerable<TEntity> entities, 
            Func<TEntity, TId> idSelector, Expression<Func<TEntity, TId>> dbIdSelector)
        {
            var entityList = entities.ToList();
            if (entityList.Count == 0)
                return new List<TEntity>();

            var incomingIds = entityList
                .Select(idSelector)
                .Where(x => x != null)
                .Distinct()
                .ToList();

            if (incomingIds.Count == 0)
                return entityList;

            var memberExpr = dbIdSelector.Body as MemberExpression
                             ?? throw new InvalidOperationException("Invalid ID selector expression.");

            var propertyName = memberExpr.Member.Name;
            
            var existingIds = await _dbSet
                .AsNoTracking()
                .Where(e => incomingIds.Contains(EF.Property<TId>(e, propertyName)))
                .Select(dbIdSelector)
                .ToListAsync();

            var existingSet = existingIds.ToHashSet();

            return entityList
                .Where(e => !existingSet.Contains(idSelector(e)))
                .ToList();
        }
    }
}
