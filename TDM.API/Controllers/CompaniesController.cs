using MediatR;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.BasicInformation.Companies.Commands.CreateCompany;
using TDM.Application.BasicInformation.Companies.Commands.RemoveCompany;
using TDM.Application.BasicInformation.Companies.Commands.UpdateCompany;
using TDM.Application.BasicInformation.Companies.Queries.GetCompanies;
using TDM.Application.BasicInformation.Companies.Queries.GetCompanyById;

namespace TDM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        private readonly IMediator _mediator;

        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetCompanyByIdQuery(id));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(new GetCompaniesQuery(pageNumber, pageSize));

            return Ok(ApiResponse.Success(result));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCompanyCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCompanyCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteCompanyCommand(id), cancellationToken);

            return Ok(ApiResponse.Success(true, "Company deleted"));
        }
    }
}
