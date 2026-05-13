using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.BasicInformation.Companies.DTOs;
using TDM.Application.Common.Interfaces;
using TDM.Application.Common.Models;
using TDM.Domain.Common;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly TDMDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(TDMDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<PagedResult<TEntity>?> GetPagedAsync(int pageNumber, int pageSize)
        {
            var query = _dbSet.AsNoTracking();

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)                
                .ToListAsync();

            return new PagedResult<TEntity>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<IEnumerable<TEntity>?> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> GetAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
