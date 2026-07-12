using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.BasicInformation.Terminals.Commands.CreateTerminal;
using TDM.Application.Doc.IssueRequestStoreReceipt.Commands.IssueRequestConfirmation;
using TDM.Application.Doc.IssueRequestStoreReceipt.Queries.GetIssueRequestByStorageAgreementNo;

namespace TDM.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class IssueRequestStoreReceiptController : Controller
    {
        private readonly IMediator _mediator;
        public IssueRequestStoreReceiptController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("issueRequest-storeReceipt-by-ipasDeclarationNo/{ipasDeclarationNo}")]
        public async Task<IActionResult> GetIssueRequestByStorageAgreementNo(string ipasDeclarationNo)
        {
            var result = await _mediator.Send(new GetIssueRequestByStorageAgreementNoQuery(ipasDeclarationNo));
            return Ok(ApiResponse.Success(result));
        }

        [HttpPost]
        public async Task<IActionResult> IssueRequestConfirmation([FromBody] IssueRequestConfirmationCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);
            return Ok(ApiResponse.Success(id));
        }
    }
}
