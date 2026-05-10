using ExternalIntegration.Service.Application.Shared;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Client
{
    public interface IPmoRequestExecutor
    {
        Task<Response<T>> PostAsync<T>(object requestData, string terminalCode = "", CancellationToken cancellationToken = default);
    }
}
