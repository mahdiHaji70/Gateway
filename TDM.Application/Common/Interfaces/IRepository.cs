using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetAsync(Guid id);                
        Task<IEnumerable<TEntity>?> GetAllAsync();
        Task<PagedResult<TEntity>?> GetPagedAsync(int pageNumber, int pageSize);
        Task InsertAsync(TEntity entity);
        void Update(TEntity entity);        
        void Delete(TEntity entity);
    }
}
