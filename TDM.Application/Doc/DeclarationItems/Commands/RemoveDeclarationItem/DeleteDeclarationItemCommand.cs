using MediatR;

namespace TDM.Application.Doc.DeclarationItems.Commands.RemoveDeclarationItem
{
    public class DeleteDeclarationItemCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteDeclarationItemCommand(Guid id)
        {
            Id = id;
        }
    }
}
