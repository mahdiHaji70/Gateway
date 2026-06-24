using MediatR;

namespace TDM.Application.BasicInformation.Terminals.Commands.RemoveTerminal
{
    public class DeleteTerminalCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteTerminalCommand(Guid id)
        {
            Id = id;
        }
    }
}
