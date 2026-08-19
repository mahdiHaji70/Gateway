using Microsoft.EntityFrameworkCore;
using TDM.Application.Common.Interfaces;
using TDM.Domain.Entities;

namespace TDM.Infrastructure.Persistence.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(TDMDbContext context) : base(context)
        {
        }

        public async Task<List<Company>> GetByNationalIdsAsync(IEnumerable<string> nationalIds, CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking().Where(x => nationalIds.Contains(x.NationalId)).ToListAsync(cancellationToken);
        }
    }
}