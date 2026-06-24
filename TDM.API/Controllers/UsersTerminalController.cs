using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.BasicInformation.UsersTerminal.Commands.CreateUserTerminal;
using TDM.Application.BasicInformation.UsersTerminal.Commands.RemoveUserTerminal;
using TDM.Application.BasicInformation.UsersTerminal.Commands.UpdateUserTerminal;
using TDM.Application.BasicInformation.UsersTerminal.Queries.GetUserTerminalById;
using TDM.Application.BasicInformation.UsersTerminal.Queries.GetUsersTerminal;
using TDM.Application.BasicInformation.UsersTerminal.Queries.GetUserTerminalByNationalId;
using TDM.Application.BasicInformation.UsersTerminal.Queries.GetCurrentUserTerminal;

namespace TDM.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersTerminalController : Controller
    {
        private readonly IMediator _mediator;

        public UsersTerminalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetUserTerminalByIdQuery(id));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet("GetByNationalId/{nationalId}")]
        public async Task<IActionResult> GetByNationalId(string nationalId)
        {
            var result = await _mediator.Send(new GetUserTerminalByNationalIdQuery(nationalId));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet("GetCurrentUserTerminal")]
        public async Task<IActionResult> GetCurrentUserTerminal()
        {
            var result = await _mediator.Send(new GetCurrentUserTerminalQuery());

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(new GetUsersTerminalQuery(pageNumber, pageSize));

            return Ok(ApiResponse.Success(result));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserTerminalCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserTerminalCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteUserTerminalCommand(id), cancellationToken);

            return Ok(ApiResponse.Success(true, "User Terminal deleted"));
        }
    }
}
