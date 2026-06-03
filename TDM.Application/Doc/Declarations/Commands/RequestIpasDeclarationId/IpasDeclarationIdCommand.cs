using MediatR;

namespace TDM.Application.BasicInformation.Declarations.Commands.RequestIpasDeclarationId
{
    public record IpasDeclarationIdCommand : IRequest<string>
    {
        public Guid DeclarationId { get; set; }        

        public IpasDeclarationIdCommand(Guid declarationId)
        {
            DeclarationId = declarationId;
        }
    }
}
