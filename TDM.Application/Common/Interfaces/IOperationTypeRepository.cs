using TDM.Domain.Entities;

namespace TDM.Application.Common.Interfaces
{
    public interface IOperationTypeRepository : IRepository<OperationType>
    {
        Task<List<OperationType>> GetByCodesAsync(IEnumerable<string> codes, CancellationToken cancellationToken);
    }
}
