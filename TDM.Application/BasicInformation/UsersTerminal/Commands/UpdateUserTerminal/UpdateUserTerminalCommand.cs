using MediatR;

namespace TDM.Application.BasicInformation.UsersTerminal.Commands.UpdateUserTerminal
{
    public record UpdateUserTerminalCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string UserNationalId { get; init; } = default!;
        public Guid TerminalId { get; init; } = default!;


    }
}
