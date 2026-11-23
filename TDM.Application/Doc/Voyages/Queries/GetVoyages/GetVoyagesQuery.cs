using MediatR;
using TDM.Application.Doc.Voyages.DTOs;
using TDM.Application.Common.Models;

namespace TDM.Application.Doc.Voyages.Queries.GetVoyages
{
    public record GetVoyagesQuery(int PageNumber = 1, int PageSize = 10, string? Search = null) : IRequest<PagedResult<VoyageDto>>;

}
