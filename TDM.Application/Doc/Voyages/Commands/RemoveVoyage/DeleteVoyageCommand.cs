using MediatR;

namespace TDM.Application.Doc.Voyages.Commands.RemoveVoyage
{
    public class DeleteVoyageCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteVoyageCommand(Guid id)
        {
            Id = id;
        }
    }
}
