using MediatR;
using TDM.Application.Doc.Declarations.DTOs;

namespace TDM.Application.Doc.Declarations.Queries.GetDeclarationById
{
    public record GetDeclarationByIdQuery(Guid Id) : IRequest<DeclarationDto>;

}
