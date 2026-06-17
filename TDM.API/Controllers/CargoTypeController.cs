using MediatR;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.BasicInformation.CargoTypes.Commands.CreateCargoType;
using TDM.Application.BasicInformation.CargoTypes.Commands.DeleteCargoType;
using TDM.Application.BasicInformation.CargoTypes.Commands.UpdateCargoType;
using TDM.Application.BasicInformation.CargoTypes.Queries.GetCargoTypeById;
using TDM.Application.BasicInformation.CargoTypes.Queries.GetCargoTypes;

namespace TDM.API.Controllers
{
   
        [ApiController]
        [Route("api/[controller]")]
        public class CargoTypesController : Controller
        {
            private readonly IMediator _mediator;

            public CargoTypesController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(Guid id)
            {
                var result = await _mediator.Send(new GetCargoTypeByIdQuery(id));

                return Ok(ApiResponse.Success(result));
            }

            [HttpGet]
            public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
            {
                var result = await _mediator.Send(new GetCargoTypesQuery(pageNumber, pageSize));

                return Ok(ApiResponse.Success(result));
            }

            [HttpPost]
            public async Task<IActionResult> Create([FromBody] CreateCargoTypeCommand command, CancellationToken cancellationToken)
            {
                var id = await _mediator.Send(command, cancellationToken);

                return Ok(ApiResponse.Success(id));
            }

            [HttpPut]
            public async Task<IActionResult> Update([FromBody] UpdateCargoTypeCommand command, CancellationToken cancellationToken)
            {
                var id = await _mediator.Send(command, cancellationToken);

                return Ok(ApiResponse.Success(id));
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
            {
                await _mediator.Send(new DeleteCargoTypeCommand(id), cancellationToken);

                return Ok(ApiResponse.Success(true, "cargotype deleted"));
            }
        
    }
}
