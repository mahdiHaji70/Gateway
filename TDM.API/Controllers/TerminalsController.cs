using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.BasicInformation.Terminals.Commands.CreateTerminal;
using TDM.Application.BasicInformation.Terminals.Commands.RemoveTerminal;
using TDM.Application.BasicInformation.Terminals.Commands.UpdateTerminal;
using TDM.Application.BasicInformation.Terminals.Queries.GetTerminalById;
using TDM.Application.BasicInformation.Terminals.Queries.GetTerminals;
using TDM.Application.BasicInformation.Terminals.Queries.GetTerminalLookup;

namespace TDM.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TerminalsController : Controller
    {
        private readonly IMediator _mediator;

        public TerminalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetTerminalByIdQuery(id));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string? search = null)
        {
            var result = await _mediator.Send(new GetTerminalsQuery(pageNumber, pageSize, search));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet("lookup")]
        public async Task<IActionResult> GetLookup([FromQuery] string? search = null, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
            => Ok(ApiResponse.Success(await _mediator.Send(new GetTerminalLookupQuery(search, pageNumber, pageSize))));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTerminalCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTerminalCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteTerminalCommand(id), cancellationToken);

            return Ok(ApiResponse.Success(true, "Terminal deleted"));
        }
    }
}
