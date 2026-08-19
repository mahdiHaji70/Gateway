using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface ITrafficRepository : IRepository<Traffic>
    {
        Task<List<Traffic>> GetByCodesAsync(IEnumerable<string> codes, CancellationToken cancellationToken);
    }
}
