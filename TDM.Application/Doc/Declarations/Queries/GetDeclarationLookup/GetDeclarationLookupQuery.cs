using MediatR;
using TDM.Application.Common.Models;
using TDM.Application.Doc.Declarations.DTOs;

namespace TDM.Application.Doc.Declarations.Queries.GetDeclarationLookup
{
    public record GetDeclarationLookupQuery(string? Search = null, int PageNumber = 1, int PageSize = 20)
        : IRequest<PagedResult<DeclarationLookupDto>>;
}
