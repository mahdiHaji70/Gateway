using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface ICommodityRepository : IRepository<Commodity>
    {
        Task<List<Commodity>> GetByHsCodesAsync(IEnumerable<string> hsCodes, CancellationToken cancellationToken);
    }
}
