using TDM.Application.Doc.Voyages.Commands.SyncVoyages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.Doc.Voyages.Commands.CreateVoyage;
using TDM.Application.Doc.Voyages.Commands.DeleteVoyage;
using TDM.Application.Doc.Voyages.Commands.UpdateVoyage;
using TDM.Application.Doc.Voyages.Queries.GetVoyageById;
using TDM.Application.Doc.Voyages.Queries.GetVoyages;
using TDM.Application.Doc.Voyages.Queries.GetVoyageLookup;

namespace TDM.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VoyagesController : Controller
    {
        private readonly IMediator _mediator;

        public VoyagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetVoyageByIdQuery(id));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string? search = null)
        {
            var result = await _mediator.Send(new GetVoyagesQuery(pageNumber, pageSize, search));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet("lookup")]
        public async Task<IActionResult> GetLookup([FromQuery] string? search = null, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
            => Ok(ApiResponse.Success(await _mediator.Send(new GetVoyageLookupQuery(search, pageNumber, pageSize))));

        [HttpPost("sync-voyages-from-gateway")]
        public async Task<IActionResult> SyncVoyagesFromGateway(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(
                new SyncVoyagesCommand(), cancellationToken);
            return Ok(ApiResponse.Success(result));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVoyageCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateVoyageCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteVoyageCommand(id), cancellationToken);

            return Ok(ApiResponse.Success(true, "Voyage deleted"));
        }
    }
}
