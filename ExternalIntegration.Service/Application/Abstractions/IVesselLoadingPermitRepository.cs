using ExternalIntegration.Service.Domain.Entities;
using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Application.Abstractions
{

    public interface IVesselLoadingPermitRepository : IRepository<VesselLoadingPermit>
    {        
        Task<DateTime> GetLastDateAsync(string terminalCode);
        Task<VesselLoadingPermit?> GetByWarehouseReceiptIdAsync(Guid warehouseReceiptId);
        void UpdateVesselLoadingPermitApprovedAsync(Guid id, bool isApproved);
    }
}
