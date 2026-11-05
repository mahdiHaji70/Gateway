using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.BasicInformation.Cities.Commands.CreateCity;
using TDM.Application.BasicInformation.Cities.Commands.RemoveCity;
using TDM.Application.BasicInformation.Cities.Commands.UpdateCity;
using TDM.Application.BasicInformation.Cities.Queries.GetCities;
using TDM.Application.BasicInformation.Cities.Queries.GetCityLookup;
using TDM.Application.BasicInformation.Cities.Queries.GetCityById;


namespace TDM.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private readonly IMediator _mediator;

        public CitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetCityByIdQuery(id));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string? search = null)
        {
            var result = await _mediator.Send(new GetCitiesQuery(pageNumber, pageSize, search));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet("lookup")]
        public async Task<IActionResult> GetLookup([FromQuery] string? search = null, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
            => Ok(ApiResponse.Success(await _mediator.Send(new GetCityLookupQuery(search, pageNumber, pageSize))));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCityCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCityCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteCityCommand(id), cancellationToken);

            return Ok(ApiResponse.Success(true, "City deleted"));
        }
    }
}
