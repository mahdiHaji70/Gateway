using ExternalIntegration.Service.Application.Shared;
using ExternalIntegration.Service.Sync.DTOs;
using ExternalIntegration.Service.Sync.PMO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExternalIntegration.Service.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PMOController : ControllerBase
    {
        private readonly IPmoSyncService _pmoSyncService;

        public PMOController(IPmoSyncService pmoSyncService)
        {
            _pmoSyncService = pmoSyncService;
        }

        [HttpGet("GetGoodwayBill")]
        public async Task<Response<IEnumerable<GoodwayBillDto>>> GetGoodwayBill([FromQuery] DateRangeDto dto)
        {
            return await _pmoSyncService.GetGoodwayBill(dto);
        }

        [HttpPost("CreateStorageAgreement")]
        public async Task<Response<CreateStorageAgreementResultDto>> CreateStorageAgreement([FromBody] CreateStorageAgreementDto dto)
        {
            return await _pmoSyncService.CreateStorageAgreement(dto);
        }

        [HttpGet("GetStorageAgreement")]
        public async Task<Response<StorageAgreementResultDto>> GetStorageAgreement([FromQuery]  GetStorageAgreementDto dto)
        {
             var result = await _pmoSyncService.GetStorageAgreement(dto);
            return result;
        }
        [HttpPost("DeleteStorageAgreement")]
        public async  Task<Response<Boolean>> DeleteStorageAgreement([FromBody] DeleteStorageAgreementDto dto)
        {
            var result = await _pmoSyncService.DeleteStorageAgreement(dto);
            return result;
        }
        [HttpGet("GetDischargePermit")]
        public async Task<Response<IEnumerable<DischargePermitDto>>> GetDischargePermit([FromQuery] DateRangeDto dto)
        {
            return await _pmoSyncService.GetDischargePermit(dto);
        }
    }
}
