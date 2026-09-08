using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Application.Abstractions
{

    public interface IVesselLoadingPermitRepository : IRepository<VesselLoadingPermit>
    {        
        Task<DateTime> GetLastDateAsync(string terminalCode);
        void UpdateVesselLoadingPermitApprovedAsync(Guid id, bool isApproved);
    }
}
