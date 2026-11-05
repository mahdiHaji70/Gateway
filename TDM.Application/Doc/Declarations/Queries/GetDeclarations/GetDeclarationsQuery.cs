using MediatR;
using TDM.Application.BasicInformation.Cities.DTOs;
using TDM.Application.Common.Models;
using TDM.Application.Doc.Declarations.DTOs;

namespace TDM.Application.Doc.Declarations.Queries.GetDeclarations
{
    public record GetDeclarationsQuery(
        int PageNumber = 1,
        int PageSize = 10,
        string? Search = null,
        Guid? TrafficId = null,
        Guid? ConsigneeId = null,
        Guid? ConsigneeRepId = null,
        DateTime? DateFrom = null,
        DateTime? DateTo = null) : IRequest<PagedResult<DeclarationDto>>;

}
