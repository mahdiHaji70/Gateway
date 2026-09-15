using MediatR;
using TDM.Application.BasicInformation.Cities.DTOs;
using TDM.Application.Common.Models;
using TDM.Application.Doc.Declarations.DTOs;
using TDM.Application.Doc.Manifests.DTOs;

namespace TDM.Application.Doc.Manifests.Queries.GetManifests
{
    public record GetManifestsQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<ManifestListDto>>;

}
