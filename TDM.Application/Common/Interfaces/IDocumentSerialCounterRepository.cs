using TDM.Domain.Enums;

namespace TDM.Application.Common.Interfaces
{
    public interface IDocumentSerialCounterRepository
    {
        Task<long> GetNextCounterAsync(
            DocumentSerialType serialType,
            string terminalCode,
            int jalaliYear,
            CancellationToken cancellationToken);
    }
}
