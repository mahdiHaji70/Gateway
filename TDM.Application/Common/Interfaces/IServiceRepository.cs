using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task<List<Service>> GetByCodesAsync(IEnumerable<string> codes, CancellationToken cancellationToken);
    }
}
