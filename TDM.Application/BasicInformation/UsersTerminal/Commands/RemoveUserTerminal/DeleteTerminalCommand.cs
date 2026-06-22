using MediatR;

namespace TDM.Application.BasicInformation.UsersTerminal.Commands.RemoveUserTerminal
{
    public class DeleteUserTerminalCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteUserTerminalCommand(Guid id)
        {
            Id = id;
        }
    }
}
