using TDM.Application.Common.Models;

namespace TDM.Application.Common.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetAsync(Guid id);                
        Task<IEnumerable<TEntity>?> GetAllAsync();
        Task<PagedResult<TEntity>?> GetPagedAsync(int pageNumber, int pageSize);
        Task InsertRangeAsync(IEnumerable<TEntity> entities);
        Task InsertAsync(TEntity entity);
        void Update(TEntity entity);        
        void Delete(TEntity entity);
    }
}
