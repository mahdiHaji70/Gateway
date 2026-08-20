using ExternalIntegration.Service.Application.DTOs;
using ExternalIntegration.Service.Domain.Entities;

namespace ExternalIntegration.Service.Application.Abstractions
{
    public interface IManifestRepository : IRepository<Manifest>
    {
        Task<DateTime> GetLastDateAsync(string terminalCode);
        Task<IEnumerable<ManifestNoticeToApproveDto>> GetManifestsNoticeNoToApprove(string terminalCode);
        Task<Manifest?> GetManifestById(Guid id);
        Task<bool> ApproveManifestAsync(Guid id);
    }
}
