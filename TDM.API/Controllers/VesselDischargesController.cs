using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.Operation.TerminalDischarges.Commands.SendIpasTerminalDischarge;
using TDM.Application.Operation.VesselDischarges.Commands.CreateVesselDischarge;
using TDM.Application.Operation.VesselDischarges.Commands.DeleteVesselDischarge;
using TDM.Application.Operation.VesselDischarges.Commands.SendVesselDischargeToIpas;
using TDM.Application.Operation.VesselDischarges.Commands.UpdateVesselDischarge;
using TDM.Application.Operation.VesselDischarges.Queries.GetGetVesselDischarges;
using TDM.Application.Operation.VesselDischarges.Queries.GetVesselDischargeById;


namespace TDM.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VesselDischargesController : Controller
    {
        private readonly IMediator _mediator;

        public VesselDischargesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetVesselDischargeByIdQuery(id));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(new GetVesselDischargesQuery(pageNumber, pageSize));

            return Ok(ApiResponse.Success(result));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVesselDischargeCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateVesselDischargeCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteVesselDischargeCommand(id), cancellationToken);

            return Ok(ApiResponse.Success(true, "Vessel discharge deleted"));
        }


        [HttpPost("send-Vesseldischarges-to-ipas/{manifestItemId:guid}")]
        public async Task<IActionResult> SendVesselDischargesToIpas(Guid manifestItemId)
        {
            var result = await _mediator.Send(new SendVesselDischargeToIpasCommand(manifestItemId));
            return Ok(ApiResponse.Success(result));
        }
    }
}
