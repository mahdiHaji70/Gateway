using MediatR;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.BasicInformation.Countries.Commands.CreateCountry;
using TDM.Application.BasicInformation.Countries.Commands.RemoveCountry;
using TDM.Application.BasicInformation.Countries.Commands.UpdateCountry;
using TDM.Application.BasicInformation.Countries.Queries.GetCountries;
using TDM.Application.BasicInformation.Countries.Queries.GetCountryById;


namespace TDM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : Controller
    {
        private readonly IMediator _mediator;

        public CountriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetCountryByIdQuery(id));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(new GetCountriesQuery(pageNumber, pageSize));

            return Ok(ApiResponse.Success(result));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCountryCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCountryCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteCountryCommand(id), cancellationToken);

            return Ok(ApiResponse.Success(true, "Country deleted"));
        }
    }
}
