using ExternalIntegration.Service.Domain.Entities;

namespace ExternalIntegration.Service.Application.Abstractions
{

    public interface ILoadingPermitRepository : IRepository<LoadingPermit>
    {        
        Task<DateTime> GetLastDateAsync(string terminalCode);
        void UpdateLoadingPermitApprovedAsync(Guid permitId, bool isApproved);

    }
}
