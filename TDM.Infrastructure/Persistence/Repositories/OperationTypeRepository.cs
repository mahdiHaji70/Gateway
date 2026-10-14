using Microsoft.EntityFrameworkCore;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class OperationTypeRepository : Repository<OperationType>, IOperationTypeRepository
    {
        public OperationTypeRepository(TDMDbContext context) : base(context)
        {
        }

        public async Task<List<OperationType>> GetByCodesAsync(IEnumerable<string> codes, CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().Where(x => codes.Contains(x.Code)).ToListAsync(cancellationToken);
        }
    }
}