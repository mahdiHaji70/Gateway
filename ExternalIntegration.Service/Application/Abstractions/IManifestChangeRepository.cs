using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExternalIntegration.Service.Application.Abstractions
{

    public interface IManifestChangeRepository : IRepository<ManifestChange>
    {
      
        Task<DateTime> GetLastDateAsync(string terminalCode);
        Task<IEnumerable<ManifestChange>> GetByTerminalCode(string terminalCode);
    }
}
