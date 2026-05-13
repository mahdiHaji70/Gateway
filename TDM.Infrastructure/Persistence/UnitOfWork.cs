using System;
using System.Collections.Generic;
using System.Text;
using TDM.Application.Common.Interfaces;

namespace TDM.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TDMDbContext _context;

        public UnitOfWork(TDMDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
