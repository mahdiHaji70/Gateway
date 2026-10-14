using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.BasicInformation.OperationTypes.Commands.CreateOperationType;
using TDM.Application.BasicInformation.OperationTypes.Commands.RemoveOperationType;
using TDM.Application.BasicInformation.OperationTypes.Commands.UpdateOperationType;
using TDM.Application.BasicInformation.OperationTypes.Queries.GetOperationTypeById;
using TDM.Application.BasicInformation.OperationTypes.Queries.GetOperationTypes;

namespace TDM.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OperationTypesController : Controller
    {
        private readonly IMediator _mediator;

        public OperationTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetOperationTypeByIdQuery(id));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(new GetOperationTypesQuery(pageNumber, pageSize));

            return Ok(ApiResponse.Success(result));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOperationTypeCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOperationTypeCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteOperationTypeCommand(id), cancellationToken);

            return Ok(ApiResponse.Success(true, "OperationType deleted"));
        }
    }
}
