using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.BasicInformation.Traffics.Commands.CreateTraffic;
using TDM.Application.BasicInformation.Traffics.Commands.RemoveTraffic;
using TDM.Application.BasicInformation.Traffics.Commands.UpdateTraffic;
using TDM.Application.BasicInformation.Traffics.Queries.GetTrafficById;
using TDM.Application.BasicInformation.Traffics.Queries.GetTraffics;
using TDM.Application.BasicInformation.Traffics.Queries.GetTrafficLookup;

namespace TDM.API.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string? search = null)
        {
            var result = await _mediator.Send(new GetTrafficsQuery(pageNumber, pageSize, search));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet("lookup")]
        public async Task<IActionResult> GetLookup([FromQuery] string? search = null, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
            => Ok(ApiResponse.Success(await _mediator.Send(new GetTrafficLookupQuery(search, pageNumber, pageSize))));

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
