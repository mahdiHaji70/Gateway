using MediatR;
using TDM.Application.Common.Models;
using TDM.Application.Doc.DeclarationItems.DTOs;

namespace TDM.Application.Doc.DeclarationItems.Queries.GetDeclarationItemLookup
{
    public record GetDeclarationItemLookupQuery(string? Search = null, int PageNumber = 1, int PageSize = 20)
        : IRequest<PagedResult<DeclarationItemLookupDto>>;
}
