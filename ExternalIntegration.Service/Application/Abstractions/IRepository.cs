using System.Linq.Expressions;

namespace ExternalIntegration.Service.Application.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetAsync(Guid id);
        Task InsertAsync(TEntity entity);
        Task InsertBulkAsync(List<TEntity> entities);
        void Delete(Guid id);
        Task<List<TEntity>> FilterUnpersistedAsync<TId>(IEnumerable<TEntity> entities, 
            Func<TEntity, TId> idSelector, Expression<Func<TEntity, TId>> dbIdSelector);
    }
}
