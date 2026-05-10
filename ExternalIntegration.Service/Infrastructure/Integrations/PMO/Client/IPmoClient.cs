using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses;
using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Client
{
    public interface IPmoClient
    {
        Task<Response<IEnumerable<GoodwayBillResultDto>>> GetGoodwayBill(DateRangeDto dto);
        Task<Response<CreateStorageAgreementResponseDto>> CreateStorageAgreement(CreateStorageAgreementDto dto);
    }
}
