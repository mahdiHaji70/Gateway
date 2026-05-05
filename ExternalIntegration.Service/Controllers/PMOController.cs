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

        [HttpPost("GetGoodwayBill")]
        public async Task<Response<IEnumerable<GoodwayBillDto>>> GetGoodwayBill([FromBody] DateRangeDto dto)
        {
            return await _pmoSyncService.GetGoodwayBill(dto);
        }
    }
}
