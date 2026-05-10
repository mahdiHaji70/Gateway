using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Sync.PMO
{
    public interface IPmoSyncService
    {
        Task<Response<IEnumerable<GoodwayBillDto>>> GetGoodwayBill(DateRangeDto dto);
        Task<Response<CreateStorageAgreementResultDto>> CreateStorageAgreement(CreateStorageAgreementDto dto);

    }
}
