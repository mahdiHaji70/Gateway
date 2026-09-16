using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.Doc.StoreReceipts.Commands.CreateStoreReceipt;
using TDM.Application.Doc.StoreReceipts.Queries.GetStoreReceiptByStorageAgreementNo;
using TDM.Application.Doc.StoreReceipts.Commands.SendIpasStoreAllocation;

namespace TDM.API.Controllers
{
   
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StoreReceiptController : Controller
    {
        private readonly IMediator _mediator;
        public StoreReceiptController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("storeReceipt-by-ipasDeclarationNo/{ipasDeclarationNo}")]
        public async Task<IActionResult> GetStoreReceiptByStorageAgreementNo(string ipasDeclarationNo)
        {
            var result = await _mediator.Send(new GetStoreReceiptByStorageAgreementNoQuery(ipasDeclarationNo));
            return Ok(ApiResponse.Success(result));
        }

        [HttpPost("create-storeReceipt")]
        public async Task<IActionResult> CreateStoreReceipt(CreateStoreReceiptCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(ApiResponse.Success(result));
        }

        [HttpPost("send-ipas-store-allocation/{storeReceiptId:guid}")]
        public async Task<IActionResult> SendIpasStoreAllocation(Guid storeReceiptId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new SendIpasStoreAllocationCommand(storeReceiptId), cancellationToken);
            return Ok(ApiResponse.Success(result));
        }
    }
}
