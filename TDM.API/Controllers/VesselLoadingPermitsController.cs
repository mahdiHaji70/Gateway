using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.Doc.VesselLoadingPermits.Queries.GetVesselLoaadingPermitByStoreReceiptId;
using TDM.Application.Doc.VesselLoadingPermits.Commands.ConfirmVesselLoadingPermit;

namespace TDM.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VesselLoadingPermitsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VesselLoadingPermitsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("by-store-receipt/{storeReceiptId:guid}")]
        public async Task<IActionResult> GetByStoreReceiptId(
            Guid storeReceiptId,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetVesselLoaadingPermitByStoreReceiptIdQuery(storeReceiptId),
                cancellationToken);

            return Ok(ApiResponse.Success(result));
        }

        [HttpPost("confirm")]
        public async Task<IActionResult> Confirm(
            [FromBody] ConfirmVesselLoadingPermitCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(ApiResponse.Success(result));
        }
    }
}
