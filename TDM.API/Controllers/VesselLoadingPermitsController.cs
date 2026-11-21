using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.Doc.VesselLoadingPermits.Queries.GetVesselLoaadingPermitByStoreReceiptId;
using TDM.Application.Doc.VesselLoadingPermits.Commands.ConfirmVesselLoadingPermit;
using TDM.Application.Doc.VesselLoadingPermits.Queries.GetApprovedVesselLoadingPermitsByStoreReceiptId;
using TDM.Application.Doc.VesselLoadingPermits.Queries.GetVesselLoadingListByPermitId;

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

        [HttpGet("approved/by-store-receipt/{storeReceiptId:guid}")]
        public async Task<IActionResult> GetApprovedByStoreReceiptId(
            Guid storeReceiptId,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetApprovedVesselLoadingPermitsByStoreReceiptIdQuery(storeReceiptId),
                cancellationToken);

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet("loading-list/by-permit/{permitId:guid}")]
        public async Task<IActionResult> GetLoadingListByPermitId(
            Guid permitId,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetVesselLoadingListByPermitIdQuery(permitId),
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
