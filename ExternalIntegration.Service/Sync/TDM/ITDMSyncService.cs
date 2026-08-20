using ExternalIntegration.Service.Application.DTOs;
using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Sync.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExternalIntegration.Service.Sync.TDM
{
    public interface ITDMSyncService
    {
        Task<Response<IEnumerable<GoodwayBillDto>>> GetGoodwayBillByStorageAgreementId(Guid storageAgreementId,string terminalCode);
        Task<Response<IEnumerable<IssueRequestDto>>> GetIssueRequest(string storageAgreementNo);
        Task<Response<IEnumerable<StoreReceiptDto>>> GetStoreReceiptByStorageAgreementNo(string storageAgreementNo);
        Task<Response<StoreReceiptDto>> GetStoreReceiptByNo(string no);
        Task<Response<DateTime>> GetDischargePermitsLastDate(string terminalCode);
        Task<Response<DateTime>> GetGoodwayBillsLastDate(string terminalCode);
        Task<Response<DateTime>> GetIssueRequestsLastDate(string terminalCode);
        Task<Response<DateTime>> GetVoyagesLastDate();
        Task<Response<DateTime>> GetStoreReceiptsLastDate(string terminalCode);
        Task<Response<IEnumerable<IssueRequestDto>>> GetIssueRequestById(Guid id);
        Task<Response<IEnumerable<ManifestNoticeToApproveDto>>> GetManifestsNoticeNoToApprove(string terminalCode);
        Task<Response<ManifestDto>> GetManifestById(Guid id);
        Task<Response<bool>> ApproveManifestAsync(Guid id);
        Task<Response<IEnumerable<ManifestChangeDto>>> GetManifestChangesByTerminalCode(string terminalCode);
    }
}
