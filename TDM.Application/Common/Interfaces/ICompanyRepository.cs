using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<List<Company>> GetByNationalIdsAsync(IEnumerable<string> nationalIds, CancellationToken cancellationToken);
    }
}
