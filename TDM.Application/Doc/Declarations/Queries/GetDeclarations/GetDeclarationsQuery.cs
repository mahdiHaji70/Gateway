using MediatR;
using TDM.Application.BasicInformation.Cities.DTOs;
using TDM.Application.Common.Models;
using TDM.Application.Doc.Declarations.DTOs;

namespace TDM.Application.BasicInformation.Declarations.Queries.GetDeclarations
{
    public record GetDeclarationsQuery(int PageNumber = 1, int PageSize = 10) : IRequest<PagedResult<DeclarationDto>>;

}
