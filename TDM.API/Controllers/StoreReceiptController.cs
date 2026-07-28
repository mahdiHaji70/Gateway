using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.Doc.StoreReceipt.Queries.GetStoreReceiptByStorageAgreementNo;

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

        //[HttpPost]
        //public async Task<IActionResult> StoreReceiptConfirmation([FromBody] StoreReceiptConfirmationCommand command, CancellationToken cancellationToken)
        //{
        //    var id = await _mediator.Send(command, cancellationToken);
        //    return Ok(ApiResponse.Success(id));
        //}
    }
}
