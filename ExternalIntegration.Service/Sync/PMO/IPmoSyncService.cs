using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExternalIntegration.Service.Sync.PMO
{
    public interface IPmoSyncService
    {
        Task<Response<IEnumerable<GoodwayBillDto>>> GetGoodwayBill(DateRangeDto dto);
        Task<Response<CreateStorageAgreementResultDto>> CreateStorageAgreement(CreateStorageAgreementDto dto);
        Task<Response<StorageAgreementResultDto>> GetStorageAgreement(StorageAgreementDto agreementNo);
        Task<Response<Boolean>> DeleteStorageAgreement(StorageAgreementDto agreementNo);

    }
}
