using MediatR;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.BasicInformation.Declarations.Commands.CreateDeclaration;
using TDM.Application.BasicInformation.Declarations.Commands.RemoveDeclaration;
using TDM.Application.BasicInformation.Declarations.Commands.UpdateDeclaration;
using TDM.Application.BasicInformation.Declarations.Queries.GetDeclarations;
using TDM.Application.BasicInformation.Declarations.Queries.GetDeclarationById;
using TDM.Application.BasicInformation.Declarations.Commands.RequestIpasDeclarationId;


namespace TDM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeclarationsController : Controller
    {
        private readonly IMediator _mediator;

        public DeclarationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetDeclarationByIdQuery(id));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(new GetDeclarationsQuery(pageNumber, pageSize));

            return Ok(ApiResponse.Success(result));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDeclarationCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDeclarationCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteDeclarationCommand(id), cancellationToken);

            return Ok(ApiResponse.Success(true, "Declaration deleted"));
        }

        [HttpPost("request-ipas-declaration-id/{declarationId:guid}")]
        public async Task<IActionResult> RequestVerifierId(Guid declarationId)
        {
            var result = await _mediator.Send(new IpasDeclarationIdCommand(declarationId));
            return Ok(ApiResponse.Success(result));
        }
    }
}
