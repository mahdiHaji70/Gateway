using MediatR;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.BasicInformation.StoreTypes.Commands.CreateStoreType;
using TDM.Application.BasicInformation.StoreTypes.Commands.DeleteStoreType;
using TDM.Application.BasicInformation.StoreTypes.Commands.UpdateStoreType;
using TDM.Application.BasicInformation.StoreTypes.Queries.GetStoreTypeById;
using TDM.Application.BasicInformation.StoreTypes.Queries.GetStoreTypes;

namespace TDM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreTypesController : Controller
    {
        private readonly IMediator _mediator;

        public StoreTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetStoreTypeByIdQuery(id));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(new GetStoreTypesQuery(pageNumber, pageSize));

            return Ok(ApiResponse.Success(result));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStoreTypeCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStoreTypeCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteStoreTypeCommand(id), cancellationToken);

            return Ok(ApiResponse.Success(true, "Storetype deleted"));
        }
    }
}

