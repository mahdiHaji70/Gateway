using MediatR;
using TDM.Application.BasicInformation.Cities.DTOs;
using TDM.Application.Common.Models;
using TDM.Application.Doc.DeclarationItems.DTOs;

namespace TDM.Application.BasicInformation.DeclarationItems.Queries.GetDeclarationItems
{
    public record GetDeclarationItemsQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<DeclarationItemDto>>;

}
