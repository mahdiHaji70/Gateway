using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IPackageRepository : IRepository<Package>
    {
        Task<List<Package>> GetByCodesAsync(IEnumerable<string> codes, CancellationToken cancellationToken);
    }
}
