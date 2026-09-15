using MediatR;
using TDM.Application.Doc.DeclarationItems.DTOs;

namespace TDM.Application.Doc.DeclarationItems.Queries.GetDeclarationItemById
{
    public record GetDeclarationItemByIdQuery(Guid Id) : IRequest<DeclarationItemDto>;

}
