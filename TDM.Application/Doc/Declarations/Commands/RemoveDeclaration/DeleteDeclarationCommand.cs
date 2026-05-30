using MediatR;

namespace TDM.Application.BasicInformation.Declarations.Commands.RemoveDeclaration
{
    public class DeleteDeclarationCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteDeclarationCommand(Guid id)
        {
            Id = id;
        }
    }
}
