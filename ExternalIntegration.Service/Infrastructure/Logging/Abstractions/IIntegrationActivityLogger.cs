using ExternalIntegration.Service.Infrastructure.Logging.Abstractions.Models;

namespace ExternalIntegration.Service.Infrastructure.Logging.Abstractions
{
    public interface IIntegrationActivityLogger
    {
        Task LogAsync(PMOLogEntry entry, CancellationToken cancellationToken = default);
    }
}
