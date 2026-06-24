using MediatR;

namespace TDM.Application.BasicInformation.UsersTerminal.Commands.CreateUserTerminal
{
    public record CreateUserTerminalCommand : IRequest<Guid>
    {
        public string UserNationalId { get; init; } = default!;
        public Guid TerminalId { get; init; } = default!;


    }
}
