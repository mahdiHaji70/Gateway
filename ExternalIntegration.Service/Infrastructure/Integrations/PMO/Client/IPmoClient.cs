using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses;
using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Client
{
    public interface IPmoClient
    {
        Task<Response<IEnumerable<GoodwayBillResponseDto>>> GetGoodwayBill(DateRangeDto dto);
        Task<Response<CreateStorageAgreementResponseDto>> CreateStorageAgreement(CreateStorageAgreementDto dto);
        Task<Response<StorageAgreementResponseDto>> GetStorageAgreement(GetStorageAgreementDto dto);
        Task<Response<bool>> DeleteStorageAgreement(DeleteStorageAgreementDto dto);
    }
}
