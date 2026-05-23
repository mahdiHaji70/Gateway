using MediatR;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.BasicInformation.Traffics.Commands.CreateTraffic;
using TDM.Application.BasicInformation.Traffics.Commands.RemoveTraffic;
using TDM.Application.BasicInformation.Traffics.Commands.UpdateTraffic;
using TDM.Application.BasicInformation.Traffics.Queries.GetTrafficById;
using TDM.Application.BasicInformation.Traffics.Queries.GetTraffics;

namespace TDM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrafficsController : Controller
    {
        private readonly IMediator _mediator;

        public TrafficsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetTrafficByIdQuery(id));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(new GetTrafficsQuery(pageNumber, pageSize));

            return Ok(ApiResponse.Success(result));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTrafficCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTrafficCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteTrafficCommand(id), cancellationToken);

            return Ok(ApiResponse.Success(true, "Traffic deleted"));
        }
    }
}
