using ExternalIntegration.Service.Domain.Entities;

namespace ExternalIntegration.Service.Application.Abstractions
{
    public interface IManifestRepository : IRepository<Manifest>
    {
        Task<DateTime> GetLastDateAsync(string terminalCode);
    }
}
