using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Sync.TDM
{
    public interface ITDMSyncService
    {
        Task<Response<IEnumerable<GoodwayBillDto>>> GetGoodwayBillByStorageAgreementId(Guid storageAgreementId);
    }
}
