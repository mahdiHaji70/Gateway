using MediatR;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.BasicInformation.Packages.Commands.CreatePackage;
using TDM.Application.BasicInformation.Packages.Commands.RemovePackage;
using TDM.Application.BasicInformation.Packages.Commands.UpdatePackage;
using TDM.Application.BasicInformation.Packages.Queries.GetPackageById;
using TDM.Application.BasicInformation.Packages.Queries.GetPackages;

namespace TDM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackagesController : Controller
    {
        private readonly IMediator _mediator;

        public PackagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetPackageByIdQuery(id));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(new GetPackagesQuery(pageNumber, pageSize));

            return Ok(ApiResponse.Success(result));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePackageCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePackageCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeletePackageCommand(id), cancellationToken);

            return Ok(ApiResponse.Success(true, "Package deleted"));
        }
    }
}
