using MediatR;

namespace TDM.Application.BasicInformation.Terminals.Commands.CreateTerminal
{
    public record CreateTerminalCommand : IRequest<Guid>
    {
        public string Code { get; init; } = default!;
        public string Name { get; init; } = default!;
        public string PortCode { get; init; } = default!;
        public string Username { get; init; } = default!;
        public string Password { get; init; } = default!;
        public bool IsActive { get; init; } = default!;

    }
}
