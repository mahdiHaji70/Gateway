using ExternalIntegration.Service.Domain.Entities;

namespace ExternalIntegration.Service.Application.Abstractions
{
    public interface IThroughTransportRepository : IRepository<ThroughTransport>
    {
        Task<DateTime> GetLastDateAsync(string terminalCode);
    }
}
