using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExternalIntegration.Service.Sync.TDM
{
    public interface ITDMSyncService
    {
        Task<Response<IEnumerable<GoodwayBillDto>>> GetGoodwayBillByStorageAgreementId(Guid storageAgreementId,string terminalCode);
    }
}
