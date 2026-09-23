using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.Doc.LoadingPermits.Commands.ConfirmLoadingPermit;
using TDM.Application.Doc.LoadingPermits.Queries.GetLoadingPermitByStoreReceiptId;

namespace TDM.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoadingPermitsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoadingPermitsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("by-store-receipt/{storeReceiptId:guid}")]
        public async Task<IActionResult> GetByStoreReceiptId(
            Guid storeReceiptId,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new GetLoadingPermitByStoreReceiptIdQuery(storeReceiptId),
                cancellationToken);

            return Ok(ApiResponse.Success(result));
        }

        [HttpPost("confirm")]
        public async Task<IActionResult> Confirm(
            [FromBody] ConfirmLoadingPermitCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(ApiResponse.Success(result));
        }
    }
}
