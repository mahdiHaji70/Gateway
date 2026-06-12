using MediatR;
using TDM.Application.BasicInformation.Cities.DTOs;
using TDM.Application.Common.Models;
using TDM.Application.Doc.DeclarationItems.DTOs;

namespace TDM.Application.BasicInformation.DeclarationItems.Queries.GetDeclarationItemsByDeclarationId
{
    public record GetDeclarationsByDeclarationIdQuery(Guid Id) : IRequest<IEnumerable<DeclarationItemDto>>;

}
