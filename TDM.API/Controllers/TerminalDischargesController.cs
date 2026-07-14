using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.Operation.TerminalDischarges.Commands.CreateTerminalDischarge;
using TDM.Application.Operation.TerminalDischarges.Commands.DeleteTerminalDischarge;
using TDM.Application.Operation.TerminalDischarges.Commands.SendIpasTerminalDischarge;
using TDM.Application.Operation.TerminalDischarges.Commands.UpdateTerminalDischarge;
using TDM.Application.Operation.TerminalDischarges.Queries.GetGetTerminalDischarges;
using TDM.Application.Operation.TerminalDischarges.Queries.GetTerminalDischargeByDeclarationNo;
using TDM.Application.Operation.TerminalDischarges.Queries.GetTerminalDischargeById;
using TDM.Application.Operation.TerminalDischarges.Queries.GetTerminalDischargeByIpasDeclarationNo;


namespace TDM.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TerminalDischargesController : Controller
    {
        private readonly IMediator _mediator;

        public TerminalDischargesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetTerminalDischargeByIdQuery(id));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(new GetTerminalDischargesQuery(pageNumber, pageSize));

            return Ok(ApiResponse.Success(result));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTerminalDischargeCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTerminalDischargeCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteTerminalDischargeCommand(id), cancellationToken);

            return Ok(ApiResponse.Success(true, "terminaldischarge deleted"));
        }

        [HttpPost("send-to-ipas-terminaldischarge-by-id/{declarationId:guid}")]
        public async Task<IActionResult> RequestVerifierId(Guid declarationId)
        {
            var result = await _mediator.Send(new SendIpasTerminalDischargeCommand(declarationId));
            return Ok(ApiResponse.Success(result));
        }

        [HttpGet("request-goodwayBill-by-ipasDeclarationNo/{ipasDeclarationNo}")]
        public async Task<IActionResult> GetGoodwayBillByIpasDeclarationNo(string ipasDeclarationNo)
        {
            var result = await _mediator.Send(new GetGoodwayBillByIpasDeclarationNoQuery(ipasDeclarationNo));
            return Ok(ApiResponse.Success(result));
        }
      [HttpGet("request-terminaldischarge-id")]
        public async Task<IActionResult> GetTerminalDischargeByDeclarationId([FromQuery] Guid declarationId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(new GetTerminalDischargeByDeclarationIdQuery(declarationId, pageNumber, pageSize));

            return Ok(ApiResponse.Success(result));
        }

    }
}
