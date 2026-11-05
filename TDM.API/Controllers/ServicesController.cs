using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.BasicInformation.Services.Commands.CreateService;
using TDM.Application.BasicInformation.Services.Commands.RemoveService;
using TDM.Application.BasicInformation.Services.Commands.UpdateService;
using TDM.Application.BasicInformation.Services.Queries.GetServiceById;
using TDM.Application.BasicInformation.Services.Queries.GetServices;
using TDM.Application.BasicInformation.Services.Queries.GetServiceLookup;

namespace TDM.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetServiceByIdQuery(id));
            return Ok(ApiResponse.Success(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string? search = null)
        {
            var result = await _mediator.Send(new GetServicesQuery(pageNumber, pageSize, search));
            return Ok(ApiResponse.Success(result));
        }

        [HttpGet("lookup")]
        public async Task<IActionResult> GetLookup([FromQuery] string? search = null, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
            => Ok(ApiResponse.Success(await _mediator.Send(new GetServiceLookupQuery(search, pageNumber, pageSize))));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateServiceCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);
            return Ok(ApiResponse.Success(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateServiceCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);
            return Ok(ApiResponse.Success(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteServiceCommand(id), cancellationToken);
            return Ok(ApiResponse.Success(true, "Service deleted"));
        }
    }
}
