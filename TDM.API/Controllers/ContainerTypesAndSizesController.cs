using MediatR;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.BasicInformation.ContainerTypesAndSizes.Queries.GetContainerTypeAndSizeById;
using TDM.Application.BasicInformation.ContainerTypesAndSizes.Queries.GetContainerTypesAndSizes;
using TDM.Application.BasicInformation.ContainerTypesAndSizes.Commands.CreateContainerTypeAndSize;
using TDM.Application.BasicInformation.ContainerTypesAndSizes.Commands.UpdateContainerTypeAndSize;
using TDM.Application.BasicInformation.ContainerTypesAndSizes.Commands.RemoveContainerTypeAndSize;

namespace TDM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContainerTypesAndSizesController : Controller
    {
        private readonly IMediator _mediator;

        public ContainerTypesAndSizesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetContainerTypeAndSizeByIdQuery(id));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(new GetContainerTypesAndSizesQuery(pageNumber, pageSize));

            return Ok(ApiResponse.Success(result));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContainerTypeAndSizeCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateContainerTypeAndSizeCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteContainerTypeAndSizeCommand(id), cancellationToken);

            return Ok(ApiResponse.Success(true, "Container Type And Size deleted"));
        }
    }
}
