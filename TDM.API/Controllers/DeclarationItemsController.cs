using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.BasicInformation.DeclarationItems.Commands.CreateDeclarationItem;
using TDM.Application.BasicInformation.DeclarationItems.Commands.RemoveDeclarationItem;
using TDM.Application.BasicInformation.DeclarationItems.Commands.RequestIpasDeclarationItems;
using TDM.Application.BasicInformation.DeclarationItems.Commands.UpdateDeclarationItem;
using TDM.Application.BasicInformation.DeclarationItems.Queries.GetDeclarationItemById;
using TDM.Application.BasicInformation.DeclarationItems.Queries.GetDeclarationItems;
using TDM.Application.BasicInformation.DeclarationItems.Queries.GetDeclarationItemsByDeclarationId;
using TDM.Application.BasicInformation.Declarations.Commands.RequestIpasDeclarationId;


namespace TDM.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DeclarationItemsController : Controller
    {
        private readonly IMediator _mediator;

        public DeclarationItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetDeclarationItemByIdQuery(id));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(new GetDeclarationItemsQuery(pageNumber, pageSize));

            return Ok(ApiResponse.Success(result));
        }

        [HttpGet("get_by_declaration_id/{id}")]
        public async Task<IActionResult> GetByDeclarationId(Guid id)
        {
            var result = await _mediator.Send(new GetDeclarationsByDeclarationIdQuery(id));

            return Ok(ApiResponse.Success(result));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDeclarationItemCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDeclarationItemCommand command, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(command, cancellationToken);

            return Ok(ApiResponse.Success(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteDeclarationItemCommand(id), cancellationToken);

            return Ok(ApiResponse.Success(true, "Declaration Item deleted"));
        }

        [HttpGet("request-ipas-declaration-items/{declarationId:guid}")]
        public async Task<IActionResult> RequestVerifierId(Guid declarationId)
        {
            var result = await _mediator.Send(new IpasDeclarationItemsCommand(declarationId));
            return Ok(ApiResponse.Success(result));
        }
    }
}
