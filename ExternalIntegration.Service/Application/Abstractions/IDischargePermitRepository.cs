using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Application.Abstractions
{

    public interface IDischargePermitRepository : IRepository<DischargePermit>
    {        
        Task<DateTime> GetLastDateAsync();
    }
}
