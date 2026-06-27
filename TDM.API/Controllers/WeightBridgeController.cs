using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.Operation.WeightBridges.Commands.CreateWeightBridge;
using TDM.Application.Operation.WeightBridges.Commands.DeleteWeightBridge;
using TDM.Application.Operation.WeightBridges.Commands.UpdateWeightBridge;
using TDM.Application.Operation.WeightBridges.Queries.GetWeightBridgeById;
using TDM.Application.Operation.WeightBridges.Queries.GetWeightBridges;


namespace TDM.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WeightBridgesController : Controller
    {
        private readonly IMediator _mediator;

        public WeightBridgesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetWeightBridgeByIdQuery(id));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(new GetWeightBridgesQuery(pageNumber, pageSize));

            return Ok(ApiResponse.Success(result));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWeightBridgeCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateWeightBridgeCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteWeightBridgeCommand(id), cancellationToken);

            return Ok(ApiResponse.Success(true, "WeightBridge deleted"));
        }
    }
    }
