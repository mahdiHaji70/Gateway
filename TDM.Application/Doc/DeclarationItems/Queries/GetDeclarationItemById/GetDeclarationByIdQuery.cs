using MediatR;
using TDM.Application.Doc.DeclarationItems.DTOs;

namespace TDM.Application.BasicInformation.DeclarationItems.Queries.GetDeclarationItemById
{
    public record GetDeclarationItemByIdQuery(Guid Id) : IRequest<DeclarationItemDto>;

}
