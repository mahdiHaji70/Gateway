using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Requests;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses;
using ExternalIntegration.Service.Sync.DTOs;

namespace ExternalIntegration.Service.Infrastructure.Integrations.PMO.Client
{
    public interface IPmoClient
    {
        Task<Response<IEnumerable<GoodwayBillResponseDto>>> GetGoodwayBill(PmoDateRangeDto dto);
        Task<Response<CreateStorageAgreementResponseDto>> CreateStorageAgreement(CreateStorageAgreementRequestDto dto);
        Task<Response<StorageAgreementResponseDto>> GetStorageAgreement(GetStorageAgreementDto dto);
        Task<Response<bool>> DeleteStorageAgreement(DeleteStorageAgreementDto dto);
        Task<Response<IEnumerable<DischargePermitResponseDto>>> GetDischargePermit(PmoDateRangeDto dto);
        Task<Response<Guid>> TruckTerminalDischarge(TruckTerminalDischargeRequestDto dto);
        Task<Response<IEnumerable<IssueRequestResponseDto>>> GetIssueRequest(PmoDateRangeDto dto);
        Task<Response<GetDataWithPagingDto<VoyageResponseDto>>> GetVoyages(PmoDateRangeWithPagingDto dto);
        Task<Response<VoyageResponseDto>> GetVoyageByNoticeNo(VoyageByNoticeNoRequestDto dto);
        Task<Response<string>> IssueRequestConfirmation(IssueRequestConfirmationRequestDto dto);
        Task<Response<GetDataWithPagingDto<StoreReceiptDto>>> GetStoreReceipts(PmoDateRangeWithPagingDto dto);


    }
}
