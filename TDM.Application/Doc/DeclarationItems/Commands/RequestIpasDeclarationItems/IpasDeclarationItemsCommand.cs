using MediatR;

namespace TDM.Application.Doc.DeclarationItems.Commands.RequestIpasDeclarationItems
{
    public record IpasDeclarationItemsCommand : IRequest<Guid>
    {
        public Guid DeclarationId { get; set; }        

        public IpasDeclarationItemsCommand(Guid declarationId)
        {
            DeclarationId = declarationId;
        }
    }
}
