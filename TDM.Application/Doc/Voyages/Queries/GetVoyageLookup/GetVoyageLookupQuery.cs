using MediatR;
using TDM.Application.Doc.Voyages.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.Doc.Voyages.Queries.GetVoyageLookup
{
    public record GetVoyageLookupQuery(string? Search = null, int PageNumber = 1, int PageSize = 20)
        : IRequest<PagedResult<VoyageDto>>;
}
