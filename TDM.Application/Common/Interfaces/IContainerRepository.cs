using TDM.Application.Common.Models;
using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IContainerRepository : IRepository<Container>
    {
        Task<List<Container>> GetByNoAndCodesAsync(IEnumerable<(string, string)> codes, CancellationToken cancellationToken);

    }
}