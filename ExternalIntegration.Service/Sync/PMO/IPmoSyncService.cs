using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Infrastructure.Integrations.PMO.Responses;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExternalIntegration.Service.Sync.PMO
{
    public interface IPmoSyncService
    {
        Task<Response<IEnumerable<GoodwayBillDto>>> GetGoodwayBill(DateRangeDto dto);
        Task<Response<CreateStorageAgreementResultDto>> CreateStorageAgreement(CreateStorageAgreementDto dto);
        Task<Response<StorageAgreementResultDto>> GetStorageAgreement(GetStorageAgreementDto agreementNo);
        Task<Response<Boolean>> DeleteStorageAgreement(DeleteStorageAgreementDto agreementNo);
        Task<Response<IEnumerable<DischargePermitDto>>> GetDischargePermit(DateRangeDto dto);
        Task<Response<Guid>> SubmitTruckTerminalDischarge(TruckTerminalDischargeDto dto);
        Task<Response<IEnumerable<IssueRequestDto>>> GetIssueRequest(DateRangeDto dto);
        Task<Response<IEnumerable<VoyageDto>>> GetVoyages(DateRangeWithPagingDto dto);
        Task<Response<VoyageDto>> GetVoyageByNoticeNo(VoyageByNoticeNoDto dto);
        Task<Response<string>> IssueRequestConfirmation(IssueRequestConfirmationDto dto);
        Task<Response<IEnumerable<StoreReceiptDto>>> GetStoreReceipts(DateRangeWithPagingDto dto);
        Task<Response<bool>> SendStoreReceiptAllocation( SendStoreReceiptAllocationDto dto);
        Task<Response<IEnumerable<ManifestDto>>> GetManifests(DateRangeWithPagingDto dto);
        Task<Response<IEnumerable<ManifestChangeDto>>> GetManifestChanges(DateRangeWithPagingDto dto);
        Task<Response<ManifestDto>> GetManifestById(Guid id, string terminalCode);
    }
}
