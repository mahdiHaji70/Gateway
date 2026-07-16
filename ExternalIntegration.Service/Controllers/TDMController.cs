using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Sync.DTOs;
using ExternalIntegration.Service.Sync.TDM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExternalIntegration.Service.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TDMController : ControllerBase
    {
        private readonly ITDMSyncService _tdmSyncService;

        public TDMController(ITDMSyncService tdmSyncService)
        {
            _tdmSyncService = tdmSyncService;
        }
        [HttpGet("GetGoodwayBillByStorageAgreementId")]
        public async Task<Response<IEnumerable<GoodwayBillDto>>> GetGoodwayBillByStorageAgreementId([FromQuery] Guid storageAgreementId, [FromQuery] string terminalCode)
        {
            return await _tdmSyncService.GetGoodwayBillByStorageAgreementId(storageAgreementId, terminalCode);
        }
        [HttpGet("GetIssueRequestByStorageAgreementNo")]
        public async Task<Response<IEnumerable<IssueRequestDto>>> GetIssueRequestByStorageAgreementNo([FromQuery]  string storageAgreementNo)
        {
            return await _tdmSyncService.GetIssueRequest(storageAgreementNo);
        }
        [HttpGet("GetStoreReceiptByStorageAgreementNo")]
        public async Task<Response<IEnumerable<StoreReceiptDto>>> GetStoreReceiptByStorageAgreementNo([FromQuery] string storageAgreementNo)
        {
            return await _tdmSyncService.GetStoreReceiptByStorageAgreementNo(storageAgreementNo);
        }
        [HttpGet("GetStoreReceiptByNo")]
        public async Task<Response<StoreReceiptDto>> GetStoreReceiptByNo([FromQuery] string no)
        {
            return await _tdmSyncService.GetStoreReceiptByNo(no);
        }

    }
}
