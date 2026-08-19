using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TDM.API.Common.Models;
using TDM.Application.BasicInformation.DeclarationItems.Commands.RequestIpasDeclarationItems;
using TDM.Application.Doc.Manifests.Commands.CreateManifest;
using TDM.Application.Doc.Manifests.Queries.GetExternalManifestById;
using TDM.Application.Doc.Manifests.Queries.GetVoyageNumbers;

namespace TDM.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ManifestsController : Controller
    {
        private readonly IMediator _mediator;

        public ManifestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("request-manifest-voyage-numbers/{terminalCode}")]
        public async Task<IActionResult> GetManifestVoyageNumbers(string terminalCode)
        {
            var result = await _mediator.Send(new GetVoyageNumbersQuery(terminalCode));
            return Ok(ApiResponse.Success(result));
        }

        [HttpGet("request-manifest/{id}")]
        public async Task<IActionResult> GetManifestById(Guid id)
        {
            var result = await _mediator.Send(new GetExternalManifestByIdQuery(id));
            return Ok(ApiResponse.Success(result));
        }

        [HttpPost("create-manifest")]
        public async Task<IActionResult> CreateManifest(CreateManifestCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(ApiResponse.Success(result));
        }
    }
}
